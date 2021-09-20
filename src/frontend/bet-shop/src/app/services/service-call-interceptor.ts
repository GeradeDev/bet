
import {of as observableOf, throwError as observableThrowError,  Observable } from 'rxjs';

import {tap, catchError} from 'rxjs/operators';
import { SessionService } from './session.service';
import { AlertService } from './alert.service';
import { Injectable, Injector } from '@angular/core';



import { ConfigService, Configuration } from '../services/config.service';

import {
    HttpErrorResponse,
    HttpEvent,
    HttpHandler,
    HttpHeaders,
    HttpInterceptor,
    HttpRequest,
    HttpResponse,
} from '@angular/common/http';

@Injectable()
export class ServiceCallInterceptor implements HttpInterceptor {
  private alertService: AlertService;
  private session: SessionService;
  constructor(private injector: Injector, private config: ConfigService) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.alertService = this.injector.get(AlertService);
    this.session = this.injector.get(SessionService);
    const sessionToken = this.session.getSessionToken();
    const prodConfig = 'assets/config/prod.json'; //url to bypass
    const devConfig = 'assets/config/dev.json'; //url to bypass
    var versionNumber : Configuration = null;
    const Empty = '';

    if (!(req.url === prodConfig || req.url === devConfig)){
      versionNumber = this.config.getConfiguration();
    }

    if (sessionToken !== null) {
     req = req.clone({setHeaders: { 
          'Content-Type': 'application/json; charset=utf-8', 
          'Authorization': 'Bearer ' + sessionToken
        }});
    }else {
      req = req.clone({setHeaders: { 'Content-Type': 'application/json; charset=utf-8'}});
    }

    return next.handle(req).pipe(
      // Only way to mutate the error response
      catchError(err => {
        if (err instanceof HttpErrorResponse && err.status === 0) {
          return observableThrowError(new HttpErrorResponse({
            error: 'No response from server',
            headers: err.headers,
            status: err.status,
            statusText: err.statusText,
            url: err.url || undefined
            })
          );
        } else if (err.status >= 200 && err.status < 300) {
          const res = new HttpResponse({
            body: null,
            headers: err.headers,
            status: err.status,
            statusText: err.statusText,
            url: err.url
          });
          return observableOf(res);
        }
        return observableThrowError(err);
      }),
      tap(null
      /* (event: HttpEvent<any>) => {
      if (event instanceof HttpResponse) {
        // do stuff with response if you want
      }
    } */
    , (err) => {
      debugger;
      if (err instanceof HttpErrorResponse && typeof err.error !== 'string') {
        if (err.status === 404) {
          this.alertService.error('Error 404: Requested service not found');
        } else  if  (err.status === 401) {
          this.session.logout(true);
          this.alertService.error('Authentication failed. Please log in again.');
        } else {
          this.alertService.error('No response from server');
        }
      } else if (err instanceof HttpErrorResponse && typeof err.error === 'string') {
          if  (err.status === 400) {
            this.alertService.error(err.error);
          }
      }
    }),);
  }
}
