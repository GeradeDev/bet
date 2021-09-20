import { Component, OnInit } from '@angular/core';

import { AlertService } from './../../services/alert.service';
import { CartService } from './../../services/cart.service';
import { AuthenticationService } from './../../services/authentication.service';

import { ShoppingCart } from '../../shared/models/shoppingtcart'


@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {

  currentCart:ShoppingCart;
  IsLoggedIn:boolean;
  Loading:boolean;

  constructor(private cartService: CartService, private alertService: AlertService, private authSrvc: AuthenticationService) {
    this.Loading = false;
  }

  ngOnInit(): void {
    this.currentCart = this.cartService.getUserCart();
    this.IsLoggedIn = this.authSrvc.isLoggedIn();

    this.currentCart = this.cartService.getUserCart();

    if(this.currentCart == null){
      this.currentCart = new ShoppingCart();
      this.currentCart.items = [];
      this.currentCart.cartTotal = 0;

      this.cartService.setUserCart(this.currentCart);
    }

    this.cartService.loggedInUserCart.next(this.currentCart);
  }

  CheckOut(){
    this.Loading = true;

    this.cartService.checkoutCart(this.currentCart).subscribe(Response => {
      this.alertService.success("Order was successfully placed.");

      this.currentCart = new ShoppingCart();
      this.currentCart.items = [];
      this.currentCart.cartTotal = 0;

      this.cartService.setUserCart(this.currentCart);
      this.cartService.loggedInUserCart.next(this.currentCart);
      this.Loading = false;
    },
    errorResponse => {
      this.alertService.error(errorResponse.error);
      this.Loading = false;
    });
  }
}
