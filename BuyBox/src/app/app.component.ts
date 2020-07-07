import {SessionService} from './services/session.service';
import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import {TokenComponent} from './components/token/token.component';
import {ProductComponent} from './components/product/product.component';

declare var jQuery: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit, AfterViewInit {

  @ViewChild(TokenComponent)
  tokenComponent: TokenComponent;
  @ViewChild(ProductComponent)
  productComponent: ProductComponent;

  constructor(private api: SessionService) {  }
  ngOnInit(): void {
    this.api.sessionHead();
  }

  ngAfterViewInit(): void {
    const parent = this;
    this.productComponent.notify = () => {
      parent.tokenComponent.notify();
    };
  }
}
