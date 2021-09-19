import { Component, OnInit ,NgZone} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AuthenticationService } from '../../services/authentication.service';
import { AlertService } from '../../services/alert.service';

@Component({
    moduleId: module.id,
    styleUrls: ['./login.component.scss'],
    templateUrl: 'login.component.html'
})

export class LoginComponent implements OnInit {

    constructor() { 

    }

    ngOnInit() {

    }
}