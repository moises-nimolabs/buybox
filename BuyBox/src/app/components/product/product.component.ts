import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {ConfirmationComponent} from '../confirmation/confirmation.component';
import {SellableItemService} from '../../services/sellable-item.service';
import {PurchaseComponent} from '../purchase/purchase.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements AfterViewInit {
  @ViewChild(ConfirmationComponent)
  confirmationComponent: ConfirmationComponent;
  @ViewChild(PurchaseComponent)
  purchaseComponent: PurchaseComponent;

  constructor(private service: SellableItemService) {
  }

  ngAfterViewInit(): void {

  }

  buyProduct(id: number): void {
    const parent = this;
    this.confirmationComponent.title = 'Confirm';
    this.confirmationComponent.message = `Are you sure you want this product?`;
    this.confirmationComponent.confirm = () => {
      this.service.sellableItemGet(id, {
        next(data: any): void {
          parent.purchaseComponent.model = data;
          parent.purchaseComponent.show();
        }
      });
    };
    this.confirmationComponent.show();
  }

  notify(): void {

  }
}
