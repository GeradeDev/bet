import { Component, OnInit } from '@angular/core';

import { ProductsService } from '../../services/products.service'
import { AlertService } from '../../services/alert.service';
import { SessionService } from './../../services/session.service';
import { CartService } from './../../services/cart.service';
import { PagerService } from '../../services/pager.service';

import { SessionUser } from './../../shared/models/SessionUser';
import { ProductDTO } from '../../shared/models/ProductDTO'
import { ShoppingCart } from '../../shared/models/shoppingtcart'
import { CartItem } from '../../shared/models/cartitem'
import { Login } from 'src/app/shared/models/login';


@Component({
  moduleId: module.id,
  styleUrls: ['./products.component.scss'],
  templateUrl: 'products.component.html'
})

export class ProductsComponent implements OnInit {

  products : ProductDTO[];
  pageOfItems: Array<any>
  currentCart:ShoppingCart;
  thisCartItem:CartItem;
  Loading:boolean;

  pager: any = {};
  pagedItems: any[];

  constructor(private productsSrvc: ProductsService, private alertService: AlertService, private cartService: CartService, private pagerService: PagerService) {
    this.products = new Array<ProductDTO>();
    this.Loading = false;
  }

  ngOnInit(): void {

    this.Loading = true;
    this.productsSrvc.getProducts().subscribe(response => {
      this.products = response;
      this.setPage(1);
      this.Loading = false;
    },
    errorResponse => {
      this.alertService.error(errorResponse.error);
      this.Loading = false;
    });

    this.currentCart = this.cartService.getUserCart();

    if(this.currentCart == null){
      this.currentCart = new ShoppingCart();
      this.currentCart.items = [];
      this.currentCart.cartTotal = 0;

      this.cartService.setUserCart(this.currentCart);
    }

    this.cartService.loggedInUserCart.next(this.currentCart);
  }

  setSelectedQuantity(quantitySelected:any, productId:string){
    let availProduct = this.products.find(d =>d.id == productId);
    const index: number = this.products.indexOf(availProduct);
    this.products[index].selectedQuantity = quantitySelected;
  }

  addProductToCart(prodToAdd: ProductDTO){
    let prodInCart = this.currentCart.items.find(d =>d.id == prodToAdd.id);

    if(prodInCart == null){
      var cartItem = new CartItem();
      cartItem = prodToAdd as unknown as CartItem;
      cartItem.quantity = prodToAdd.selectedQuantity;

      this.currentCart.items.push(cartItem);
      this.updateCart();
    }
    else{
      const index: number = this.currentCart.items.indexOf(prodInCart);
      let quantityToAdd: number = prodToAdd.selectedQuantity;

      this.currentCart.items[index].quantity = quantityToAdd;

      this.updateCart();
    }
  }

  updateCart(){

    var cartTotal = 0;
    this.currentCart.items.forEach(c => {
      var lineTotal = (c.price * c.quantity);
      cartTotal += lineTotal;
    });

    this.currentCart.cartTotal = cartTotal;
    this.cartService.setUserCart(this.currentCart);
    this.cartService.loggedInUserCart.next(this.currentCart); 
  }

  setPage(page: number) {
      // get pager object from service
      this.pager = this.pagerService.getPager(this.products.length, page,6);
  
      // get current page of items
      this.pagedItems = this.products.slice(this.pager.startIndex, this.pager.endIndex + 1);
    }
}
