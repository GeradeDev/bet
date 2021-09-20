import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { ShoppingCart } from '../shared/models/shoppingtcart';
import { Exception } from '../shared/Exception';
import { Observable, Subject } from 'rxjs';

import { ServerService } from './server.service';

import { Response } from './../shared/models/reponse';

@Injectable()
export class CartService {

    constructor(private router: Router, private serverService: ServerService) { }
    private betCart = 'BetShopCart';

    loggedInUserCart = new Subject<ShoppingCart>(); 

    setUserCart(cart: ShoppingCart): void {
        localStorage.setItem(this.betCart, JSON.stringify(cart));
    }

    getUserCart(): ShoppingCart {
        return JSON.parse(localStorage.getItem(this.betCart)) as ShoppingCart;
    }

    checkoutCart(cart: ShoppingCart) : Observable<Response>{
        return this.serverService.post<Response>('checkout', cart);
    }
}