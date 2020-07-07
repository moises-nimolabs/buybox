import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {TokenService} from './token.service';
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
  confComp: ConfirmationComponent;

  cashBackModalId = 'token-cashback-modal';
  @ViewChild(CashbackComponent)
  cbComp: CashbackComponent;


  constructor(private service: TokenService) {
  }

  ngAfterViewInit(): void {
    const parent = this;
    this.service.tokensGet({
      next(data): void {
        parent.total = data.total;
      }
    });
  }

  cancel(): void {
    const parent = this;
    this.confComp.title = this.cancellationModal.title;
    this.confComp.message = this.cancellationModal.message;
    this.confComp.confirm = () => {
      this.service.tokensDelete({
        next(data: any): void {
          parent.cbComp.model = data;
          const casBackModal = jQuery('#token-cashback-modal div:first-child');
          casBackModal.on('hidden.bs.modal', f => {
            jQuery('.modal-backdrop').remove();
          });
          casBackModal.modal('show');
          parent.getTokens();
        }
      });
    };

    const modal = jQuery('#token-cancel-confirmation div:first-child');
    modal.on('hidden.bs.modal', f => {
      jQuery('.modal-backdrop').remove();
    });
    modal.modal('show');
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
}
