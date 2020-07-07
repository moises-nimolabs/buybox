import {AfterViewInit, Component, ElementRef} from '@angular/core';
declare var jQuery: any;
@Component({
  selector: 'app-cashback',
  templateUrl: './cashback.component.html',
  styleUrls: ['./cashback.component.css']
})
export class CashbackComponent implements AfterViewInit {
  model: any = {
    total: 0,
    items: []
  };

  constructor(private elementRef: ElementRef) {
  }

  ngAfterViewInit(): void {
    const nativeElement = this.elementRef.nativeElement;
    const child = nativeElement.firstChild;
    jQuery(child).on('hidden.bs.modal', () => {
      jQuery('.modal-backdrop').remove();
    });
  }
}
