import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard, LoginGuard } from './services/authentication.service';

import { HomeComponent } from './Components/common/home/home.component';
import { LoginComponent } from './Components/Login/login.component'
import { RegistrationComponent } from './Components/registration/registration.component'
import { ProductsComponent } from './Components/products/products.component'
import { CheckoutComponent } from './Components/checkout/checkout.component'

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegistrationComponent },
  { path: '', canActivate: [AuthGuard], component: HomeComponent, children: [
    { path: 'products', component: ProductsComponent },
    { path: '', redirectTo: 'products', pathMatch: 'full' },
    { path: 'checkout', component: CheckoutComponent },
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  providers: [LoginGuard, AuthGuard],
  exports: [RouterModule]
})
export class AppRoutingModule { }
