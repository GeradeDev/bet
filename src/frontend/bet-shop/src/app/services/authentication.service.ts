
import { map } from 'rxjs/operators/map';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ServerService } from './server.service';
import { SessionUser } from '../shared/models/SessionUser';
import { SessionService } from './session.service';

@Injectable()
export class AuthenticationService {
    constructor(private server: ServerService, private session: SessionService) { }

    public isLoggedIn(): boolean {
      const sessionUser = this.session.getSessionUser();
      return sessionUser !== null && sessionUser.sessionToken !== null && sessionUser.sessionToken !== '';
    }

    login(username: string, pin: string) {
        return this.server.post<SessionUser>('authenticate',
          { username: username, pin: pin }).pipe(
            map(response => {
              
              // login successful if there's a jwt token in the response
              response.initialLogin = { roles:response.roles,
                                        serviceProvider:response.serviceProvider,
                                        serviceProviderID:response.serviceProviderID,
                                        isInitialLogIn:true
              }

              
              this.session.setSessionUser(response);
              this.session.logoutListener.next(false);
              return response.passwordChangeRequired;
              // store user details and jwt token in local storage to keep user logged in between page refreshes
          }));
    }

    logout() {
        // remove user from local storage to log user out
        this.session.logout();
    }

    resetLogin(){
      this.session.resetLogin();
    }
}

import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Router, RouterStateSnapshot } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate, CanActivateChild {

    constructor(private router: Router, private authenticationService: AuthenticationService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.authenticationService.isLoggedIn()) {
            // logged in so return true
            return true;
        }

        // not logged in so redirect to login page with the return url
        if (state.url !== '/') {
          this.router.navigate(['/login'], { queryParams: { returnUrl: state.url }});
        } else {
          this.router.navigate(['/login']);
        }
        return false;
    }

    canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
      return this.canActivate(childRoute, state);
    }
}

@Injectable()
export class LoginGuard implements CanActivate {

    constructor(private router: Router, private authenticationService: AuthenticationService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.authenticationService.isLoggedIn()) {
            // logged in so return true
            this.router.navigate(['/']);
            return false;
        }
        return true;
    }
}
