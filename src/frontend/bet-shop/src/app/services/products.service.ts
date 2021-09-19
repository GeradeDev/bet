
import { map } from 'rxjs/operators/map';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { ServerService } from './server.service';

import { ProductDTO } from '../shared/models/ProductDTO';

@Injectable()
export class ProductsService {
    constructor(private server: ServerService) { }

    getProducts() : Observable<ProductDTO[]>{
        return this.server.get<ProductDTO[]>('Products/');
    }
}