import { Injectable, Injector } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Console, debug } from 'console';

export class Configuration {
  BASE_API_URL: string;
  WEB_VERSION: string;
  SIGNAL_API: string;

  SIGNAL_PRESENCE: string;
}

@Injectable()
export class ConfigService {
  private config: Configuration;

  constructor( private http: HttpClient) {
  }

  load(): Promise<Configuration> {
    let env = 'prod';
    if (environment.production) {
      env = 'prod';
    } else {
      env = 'dev';
    }
    
    const promise = this.http.get<Configuration>('assets/config/' + env + '.json').toPromise();
    promise.then(config => this.config = config);
    return promise;
  }

  getConfiguration(): Configuration {
    return this.config;
  }
}
