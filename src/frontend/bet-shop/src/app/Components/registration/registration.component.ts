import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';


import { AuthenticationService } from '../../services/authentication.service';
import { AlertService } from '../../services/alert.service';
import { SessionService } from './../../services/session.service';
import { SessionUser } from './../../shared/models/SessionUser';

import { Register } from '../../shared/models/register';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  model: Register;
  loading = false;

  constructor(private route: ActivatedRoute, private router: Router, private authenticationService: AuthenticationService, private sessionService: SessionService, private alertService: AlertService) {

      this.model = new Register();
   }

  ngOnInit(): void {
  }

  SignUp(){

    this.model.Username = this.model.Email.split('@')[0];
    this.authenticationService.registerUser(this.model).subscribe(response => {
      this.alertService.success("Rehistration successful. Please login.");
    },
    errorResponse => {
      this.alertService.error(errorResponse.error.message);
      this.loading = false;
    });
  }
}
