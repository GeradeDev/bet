import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SessionService } from './session.service';
import { SessionUser } from '../shared/models/SessionUser';
import { ConfigService } from '../services/config.service';
import { AlertService } from './alert.service';

@Injectable()
export class ServerService {
    constructor(private http: HttpClient, private session: SessionService, private config: ConfigService, private alert: AlertService) { }
    private serviceUrl = this.config.getConfiguration().BASE_API_URL;

    post<T>(apiPath: string, body: object, endpointUrl?:string, options?: object): Observable<T> {
      return this.http.post<T>((endpointUrl !== undefined ? endpointUrl: this.serviceUrl) + apiPath, body,options);
    }

    get<T>(apiPath: string, endpointUrl?:string): Observable<T> {
      const headers = new HttpHeaders();
      headers.set('Access-Control-Allow-Origin', '*');
      return this.http.get<T>((endpointUrl !== undefined ? endpointUrl: this.serviceUrl) + apiPath, { headers });
    }

    put<T>(apiPath: string, body: object, endpointUrl?:string): Observable<T> {
      return this.http.put<T>((endpointUrl !== undefined ? endpointUrl: this.serviceUrl) + apiPath, body);
    }

    delete<T>(apiPath: string, body: object, endpointUrl?:string): Observable<T> {
      return this.http.delete<T>((endpointUrl !== undefined ? endpointUrl: this.serviceUrl) + apiPath, body);
    }

    downloadFile<T>(apiPath: string, dto: object, endpointUrl?:string, isNotBlob:boolean = false): Observable<T> {
      this.alert.clear();
      const headers = new HttpHeaders();
      headers.set('Access-Control-Allow-Origin', '*');
      return this.http.post<T>((endpointUrl !== undefined ? endpointUrl: this.serviceUrl) + apiPath, dto, { responseType: isNotBlob ? 'json' : 'blob' as 'json' });
    }
}
