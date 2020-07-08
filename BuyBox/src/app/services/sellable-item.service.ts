import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {NextObserver} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SellableItemService {

  constructor(private http: HttpClient) {
  }

  sellableItemGet(id: number, nx: NextObserver<any>): void {
    this.http.request('GET', `/sellableitem?id=${id}`, {responseType: 'json'})
      .subscribe(nx);
  }

  sellableItemsGet(nx: NextObserver<any>) : void {
    this.http.request('GET', '/sellableitems', {responseType: 'json'})
      .subscribe(nx);
  }
}
