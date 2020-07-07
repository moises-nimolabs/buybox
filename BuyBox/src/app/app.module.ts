import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import {ApiInterceptor} from './interceptors/api.interceptor';
import { ConfirmationComponent } from './components/confirmation/confirmation.component';
import { TokenComponent } from './components/token/token.component';
import { ProductComponent } from './components/product/product.component';
import { CashbackComponent } from './components/cashback/cashback.component';

@NgModule({
  declarations: [
    AppComponent,
    ConfirmationComponent,
    TokenComponent,
    ProductComponent,
    CashbackComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: ApiInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
