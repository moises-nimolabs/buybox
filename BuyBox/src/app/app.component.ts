import {ApiService} from './services/api.service';

declare var jQuery: any;

import {Component, OnInit} from '@angular/core';
import {CompletionObserver, Observable} from 'rxjs';
import {TokenCollection} from './model/token-collection';
import {PartialObserver} from 'rxjs/internal/types';
import {Token} from './model/token';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  total = 0;
  title = 'BuyBox';

  constructor(private api: ApiService) { }

  tokensGetObserver: CompletionObserver<TokenCollection> = {
    // @ts-ignore
    _parent: this,
    complete(): void { },
    error(err: any): void { },
    next(value: TokenCollection): void {
      this._parent.total = value.total;
    }
  };

  totalObserver: CompletionObserver<any> = {
    // @ts-ignore
    _parent: this,
    complete(): void {
      this._parent.api.tokensGet(this._parent.tokensGetObserver);
    },
    error(err: any): void { },
    next(value: Token): void { }
  };

  addTokens(id: string): void  {
    this.api.tokensPost({ id, value: 0 }, this.totalObserver);
  }

  buyProduct(id: number): void {
    jQuery('#confirm').modal('show');
  }

  cancel(): void {
    this.api.tokensDelete(this.totalObserver);
  }

  ngOnInit(): void {
    this.api.sessionHead();
    this.api.tokensGet(this.tokensGetObserver);
  }
}
