import {Injectable} from '@angular/core';
import {environment} from '../../environments/environment';

import {HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable()
export class ApiInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const apiRequest = request.clone({ url: `${environment.apiEndpoint}${request.url}`, withCredentials: true});
    return next.handle(apiRequest);
  }
}
