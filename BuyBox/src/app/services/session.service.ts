import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({providedIn: 'root'})
export class SessionService {
  constructor(private http: HttpClient) {
  }

  sessionHead(): void {
    this.http.request('HEAD', '/session')

      .subscribe(o => {
        return null;
      });
  }
}
