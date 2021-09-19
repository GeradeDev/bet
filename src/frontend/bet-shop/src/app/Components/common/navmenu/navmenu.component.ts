import { Router } from '@angular/router';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { AuthenticationService } from '../../../services/authentication.service';
import { environment } from '../../../../environments/environment';
import { ServerService } from '../../../services/server.service';
import { SessionService } from '../../../services/session.service';
import { AlertService } from '../../../services/alert.service';

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.scss']
})

export class NavMenuComponent {
  public isLoggedIn = false;

  constructor(private authenticationService: AuthenticationService, private sessionService: SessionService, private router: Router) {
    this.isLoggedIn = this.authenticationService.isLoggedIn();
    console.log(this.sessionService.getSessionUser());
  }
  
  public LogOutIfConfirmed(): void {
    this.authenticationService.logout();
  }

  ResetLogin(){
    this.authenticationService.resetLogin();
  }
}

