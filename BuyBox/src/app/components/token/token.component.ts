import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {TokenService} from '../../services/token.service';
import {ConfirmationComponent} from '../confirmation/confirmation.component';
import {CashbackComponent} from '../cashback/cashback.component';

declare var jQuery: any;

@Component({
  selector: 'app-token',
  templateUrl: './token.component.html',
  styleUrls: ['./token.component.css']
})
export class TokenComponent implements AfterViewInit {
  total = 0;
  cancellationModal = {
    id: 'token-cancel-confirmation',
    title: 'Cancel',
    message: 'Are you sure you want to cancel and get back your tokens?'
  };

  @ViewChild(ConfirmationComponent)
  confirmationComponent: ConfirmationComponent;

  cashBackModalId = 'token-cashback-modal';
  @ViewChild(CashbackComponent)
  cashbackComponent: CashbackComponent;


  constructor(private service: TokenService) {
  }

  ngAfterViewInit(): void {
    const parent = this;
    // retrieves the user token
    this.service.tokensGet({
      next(data): void {
        parent.total = data.total;
      }
    });
  }

  cancel(): void {
    const parent = this;
    // defines the confirmation component parameters
    this.confirmationComponent.title = this.cancellationModal.title;
    this.confirmationComponent.message = this.cancellationModal.message;
    this.confirmationComponent.confirm = () => {
      this.service.tokensDelete({
        next(data: any): void {
          parent.cashbackComponent.model = data;
          parent.cashbackComponent.show();
          parent.getTokens();
        }
      });
    };
    this.confirmationComponent.show();
  }

  getTokens(): void {
    const parent: any = this;
    this.service.tokensGet({
      next(data: any): void {
        parent.total = data.total;
      }
    });
  }

  addTokens(id: string): void {
    const parent = this;
    const tk = {id, value: 0};
    this.service.tokensPost(tk, {
      next(data: any): void {
        parent.getTokens();
      }
    });
  }

  notify(): void {
    this.getTokens();
  }
}
