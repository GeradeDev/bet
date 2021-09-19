import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { SessionUser } from '../shared/models/SessionUser';
import { Exception } from '../shared/Exception';
import { BehaviorSubject } from 'rxjs';

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

    setSessionUser(sessionUser: SessionUser): void {
      localStorage.setItem(this.currentUser, JSON.stringify(sessionUser));
    }

    logout(returnToUrl?: boolean) {
      // remove user from local storage to log user out
      localStorage.removeItem(this.currentUser);
      localStorage.removeItem(this.currentRegSipSetting);
      this.logoutListener.next(true);
        
      if (returnToUrl) {
        this.router.navigate(['/products'], { queryParams: { returnUrl: this.router.routerState.snapshot.url }}).then(() => window.location.reload());
      } else {
        this.router.navigate(['/products']).then(() => window.location.reload());
      }
    }

    resetLogin(){
      //Reset login session to the initial GlobalAdmin login 
      const sessionUser = this.getSessionUser();
      if (sessionUser !== null) {
        localStorage.setItem(this.currentUser, JSON.stringify(sessionUser));
        this.router.navigate(['/']).then(() => window.location.reload());
      }
    }


    getFullname(){
      const sessionUser = this.getSessionUser();
      return sessionUser == null ? "" :  sessionUser.username;
    }

    getLoggedInUserId(){
      const sessionUser = this.getSessionUser();
      if (sessionUser !== null) {
        return 0;
      }
      return 0;
    }
}
