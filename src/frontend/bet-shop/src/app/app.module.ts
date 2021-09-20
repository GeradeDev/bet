import { NgModule, APP_INITIALIZER } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AuthenticationService } from './services/authentication.service'
import { AlertService } from './services/alert.service';
import { ServerService } from './services/server.service';
import { SessionService } from './services/session.service';
import { ConfigService } from './services/config.service';
import { ProductsService } from './services/products.service';
import { CartService } from './services/cart.service';
import { ServiceCallInterceptor } from './services/service-call-interceptor';
import { PagerService } from './services/pager.service';


import { AppComponent } from './app.component';
import { HomeComponent } from './Components/common/home/home.component';
import { NavMenuComponent } from './Components/common/navmenu/navmenu.component';
import { LoginComponent } from './Components/Login/login.component'
import { AlertComponent } from './shared/alert/alert.component';
import { RegistrationComponent } from './Components/registration/registration.component';
import { ProductsComponent } from './Components/products/products.component';
import { CheckoutComponent } from './Components/checkout/checkout.component';

export function init_app(configService: ConfigService) {
  // Load Config service before loading other components / services
  return () => configService.load();
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    LoginComponent,
    AlertComponent,
    RegistrationComponent,
    ProductsComponent,
    CheckoutComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    ConfigService,
    {
      'provide': APP_INITIALIZER,
      'useFactory': init_app,
      'deps': [ConfigService],
      'multi': true,
    },
    AuthenticationService,
    AlertService,
    ServerService,
    SessionService,
    ProductsService,
    CartService,
    [{
      provide: HTTP_INTERCEPTORS,
      useClass: ServiceCallInterceptor,
      multi: true,
    }],
    PagerService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
