
import { takeWhile } from 'rxjs/operators';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { SessionService } from '../../../services/session.service';

@Component({
  selector: 'home',
  templateUrl: './home.component.html'
})

export class HomeComponent {

  constructor(
    private session: SessionService) {
  }

  ngOnInit() {
    
  }
}