import { Component, OnInit ,NgZone} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AuthenticationService } from '../../services/authentication.service';
import { AlertService } from '../../services/alert.service';
import { SessionService } from './../../services/session.service';
import { SessionUser } from './../../shared/models/SessionUser';

import { Login } from './../../shared/models/login';

@Component({
    moduleId: module.id,
    styleUrls: ['./login.component.scss'],
    templateUrl: 'login.component.html'
})

export class LoginComponent implements OnInit {
    model: Login;
    loading = false;
    returnUrl: string;
    authUser: SessionUser;

    constructor(private route: ActivatedRoute, private router: Router, private authenticationService: AuthenticationService, private sessionService: SessionService, private alertService: AlertService) { 
       this.model = new Login();
    }

    ngOnInit() {
        
    }

    login() {

        this.model.Username = this.model.Email.split('@')[0];

        this.authenticationService.login(this.model).subscribe(response => {
            this.sessionService.setSessionUser(response);
            this.router.navigateByUrl("/products");
        },
        errorResponse => {
          this.alertService.error(errorResponse.error);
          this.loading = false;
        });
    }
}