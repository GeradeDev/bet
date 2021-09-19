import { Component, OnInit } from '@angular/core';

import { ProductsService } from '../../services/products.service'
import { AlertService } from '../../services/alert.service';
import { SessionService } from './../../services/session.service';

import { SessionUser } from './../../shared/models/SessionUser';
import { ProductDTO } from '../../shared/models/ProductDTO'


@Component({
  moduleId: module.id,
  styleUrls: ['./products.component.scss'],
  templateUrl: 'products.component.html'
})

export class ProductsComponent implements OnInit {

  products : ProductDTO[];
  pageOfItems: Array<any>

  constructor(private productsSrvc: ProductsService, private alertService: AlertService) {
    this.products = new Array<ProductDTO>();
  }

  ngOnInit(): void {

    this.productsSrvc.getProducts().subscribe(response => {
      this.products = response;
      this.alertService.success("Products Loaded");
    },
    errorResponse => {
      this.alertService.error(errorResponse.error);
    });
  }
}
