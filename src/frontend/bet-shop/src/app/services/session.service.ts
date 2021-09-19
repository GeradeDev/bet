import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { SessionUser, Exception } from '../shared/common.model';
import { EROFS } from 'constants';
import { SipRegistrationDTO } from '../shared/sip-registration-settings.model';
import { SipSettingDTO } from '../shared/sip-setting.model';
import { BehaviorSubject } from 'rxjs';
import { Userrole } from '../emums/enums';

@Injectable()
export class SessionService {
    constructor(private router: Router) { }
    private currentUser = 'currentUser';
    private currentRegSipSetting = 'rtc.currentRegSipSetting';
    private SipSettingDTO = 'rtc.SipSettingDTO';

    public logoutListener = new BehaviorSubject<boolean>(false);

    getSessionUser(): SessionUser {
      return JSON.parse(localStorage.getItem(this.currentUser)) as SessionUser;
    }

    getSessionToken(): string {
      const sessionUser = this.getSessionUser();
      if (sessionUser !== null) {
        return sessionUser.sessionToken;
      }
      return null;
    }

    getSessionServiceProviderID(): string {
      const sessionUser = this.getSessionUser();
      if (sessionUser !== null) {
        return sessionUser.serviceProviderID?.toString();
      }
      return '';
    }

    getSessionRole():string {
      const sessionUser = this.getSessionUser();
      return sessionUser?.roles?.length > 0 ? sessionUser?.roles[0] : '';
    }

    setSessionUser(sessionUser: SessionUser): void {
      if (sessionUser.roles.indexOf(Userrole.WEB_ADMIN) >= 0 || sessionUser.roles.indexOf(Userrole.GLOBAL_ADMIN) >= 0 
      || sessionUser.roles.indexOf(Userrole.CC_SUPERVISOR) >= 0 || sessionUser.roles.indexOf(Userrole.CC_OPERATOR) >= 0 
      || sessionUser.roles.indexOf(Userrole.REPORT_ADMIN) >= 0 || sessionUser.roles.indexOf(Userrole.PARCEL_ADMIN) >= 0
      || sessionUser.roles.indexOf(Userrole.ONLINE_DRIVER) >= 0 || sessionUser.roles.indexOf(Userrole.FIELD_AGENT) >= 0) {
        localStorage.setItem(this.currentUser, JSON.stringify(sessionUser));
      } else {
        throw new Exception('Access Denied');
      }
    }

    logout(returnToUrl?: boolean) {
      // remove user from local storage to log user out
      localStorage.removeItem(this.currentUser);
      localStorage.removeItem(this.currentRegSipSetting);
      this.logoutListener.next(true);
        
      if (returnToUrl) {
        this.router.navigate(['/login'], { queryParams: { returnUrl: this.router.routerState.snapshot.url }});
      } else {
        this.router.navigate(['/login']);
      }
    }

    resetLogin(){
      //Reset login session to the initial GlobalAdmin login 
      const sessionUser = this.getSessionUser();
      if (sessionUser !== null) {
        sessionUser.roles = sessionUser.initialLogin.roles;
        sessionUser.serviceProvider = sessionUser.initialLogin.serviceProvider;
        sessionUser.serviceProviderID = null;
        sessionUser.initialLogin.isInitialLogIn = true;
        localStorage.setItem(this.currentUser, JSON.stringify(sessionUser));
        this.router.navigate(['/']).then(() => window.location.reload());
      }
    }


    getFullname(){
      const sessionUser = this.getSessionUser();
      return sessionUser == null ? "" :  sessionUser.firstname + " " + sessionUser.surname;
    }

    getLoggedInUserId(){
      const sessionUser = this.getSessionUser();
      if (sessionUser !== null) {
        return sessionUser.userID;
      }
      return 0;
    }

    setSipRegistrationSetting(sipRegistration:SipRegistrationDTO): void {
        localStorage.setItem(this.currentRegSipSetting, JSON.stringify(sipRegistration));
    }

    getSipRegistrationSetting(): SipRegistrationDTO {
      return JSON.parse(localStorage.getItem(this.currentRegSipSetting)) as SipRegistrationDTO;
    }

    setSipSettingDTO(sip:SipSettingDTO): void {
      localStorage.setItem(this.SipSettingDTO, JSON.stringify(sip));
  }

  getSipSettingDTO(): SipSettingDTO {
    return JSON.parse(localStorage.getItem(this.SipSettingDTO)) as SipSettingDTO;
  }
}
