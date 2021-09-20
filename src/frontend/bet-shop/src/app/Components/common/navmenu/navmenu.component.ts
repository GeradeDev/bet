import { Router } from '@angular/router';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { AuthenticationService } from '../../../services/authentication.service';
import { environment } from '../../../../environments/environment';
import { ServerService } from '../../../services/server.service';
import { SessionService } from '../../../services/session.service';
import { AlertService } from '../../../services/alert.service';
import { CartService } from '../../../services/cart.service';


import { ShoppingCart } from '../../../shared/models/shoppingtcart'

@Component({
    selector: 'nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.scss']
})

export class NavMenuComponent {

  public isLoggedIn = false;
  currentCart:ShoppingCart;

  constructor(private authenticationService: AuthenticationService, private sessionService: SessionService, private router: Router, private cartService: CartService) {
    this.isLoggedIn = this.authenticationService.isLoggedIn();

    this.cartService.loggedInUserCart.subscribe((res: ShoppingCart) => {  
      this.currentCart = res;
    });
  }
  
  public LogOutIfConfirmed(): void {
    this.authenticationService.logout();
  }

  ResetLogin(){
    this.authenticationService.resetLogin();
  }
}

