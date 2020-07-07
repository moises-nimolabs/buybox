import {Injectable} from '@angular/core';
import {Token} from '../../model/token';
import {NextObserver} from 'rxjs';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor(private http: HttpClient) {
  }

  tokensPost(token: Token, nx: NextObserver<any>): void {
    this.http.request('POST', '/token', {responseType: 'json', body: token})
      .subscribe(nx);
  }

  tokensGet(nx: NextObserver<any>): void {
    this.http.request('GET', '/tokens', {responseType: 'json'})
      .subscribe(nx);
  }

  tokensDelete(nx: NextObserver<any>): void {
    this.http.request('DELETE', '/tokens', {responseType: 'json'})
      .subscribe(nx);
  }
}
