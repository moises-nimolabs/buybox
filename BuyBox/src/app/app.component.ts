declare var jQuery: any;

import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  total = 0;
  title = 'BuyBox';
  addTokens(id: string): void  {
    // jQuery('.toast').toast('show');
    switch (id) {
      case 'T010':
        this.total = this.total + 10;
        break;
      case 'T020':
        this.total += 20;
        break;
      case 'T050':
        this.total += 50;
        break;
      default:
        this.total += 100;
        break;
    }

    this.total = this.total / 100;
  }

  buyProduct(id: number): void {
    jQuery('#confirm').modal('show');
  }
}
