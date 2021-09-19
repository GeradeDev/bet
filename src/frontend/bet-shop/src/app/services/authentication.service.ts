
import { map } from 'rxjs/operators/map';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ServerService } from './server.service';
import { SessionUser } from '../shared/models/SessionUser';
import { SessionService } from './session.service';


import { Register } from '../shared/models/register';
import { Login } from '../shared/models/login';

@Injectable()
export class AuthenticationService {
    constructor(private server: ServerService, private session: SessionService) { }

    public isLoggedIn(): boolean {
      const sessionUser = this.session.getSessionUser();
      return sessionUser !== null && sessionUser.sessionToken !== null && sessionUser.sessionToken !== '';
    }

    login(userDetails: Login): Observable<SessionUser> {
        return this.server.post<SessionUser>('Auth/login', userDetails);
    }

    logout() {
        // remove user from local storage to log user out
        this.session.logout();
    }

    resetLogin(){
      this.session.resetLogin();
    }

    registerUser(registraion: Register): Observable<Response>{
      return this.server.post<Response>('Auth/register', registraion);
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
            this.router.navigate(['/login']);
            return false;
        }
        return true;
    }
}
