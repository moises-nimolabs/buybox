import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {TokenCollection} from '../model/token-collection';
import {CompletionObserver} from 'rxjs';
import {Token} from '../model/token';

@Injectable({providedIn: 'root'})
export class ApiService {
  constructor(private http: HttpClient) {
  }

  sessionHead(): void {
    this.http.request('HEAD', '/session')

      .subscribe(o => {
        return null;
      });
  }

  tokensPost(token: Token, obs: CompletionObserver<Token>): void {
    this.http.request('POST', '/token', {responseType: 'json', body: token})
      .subscribe(obs);
  }

  tokensGet(obs: CompletionObserver<TokenCollection>): void {
    this.http.request('GET', '/tokens', {responseType: 'json'})
      .subscribe(obs);
  }

  tokensDelete(obs: CompletionObserver<TokenCollection>): void {
    this.http.request('DELETE', '/tokens', {responseType: 'json'})
      .subscribe(obs);
  }
}
