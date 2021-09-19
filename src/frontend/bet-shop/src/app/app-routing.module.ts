import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard, LoginGuard } from './services/authentication.service';

import { LoginComponent } from './Components/Login/login.component'

const routes: Routes = [
  { path: 'login', canActivate: [LoginGuard], component: LoginComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  providers: [LoginGuard, AuthGuard],
  exports: [RouterModule]
})
export class AppRoutingModule { }
