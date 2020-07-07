import {AfterViewInit, Component, ElementRef} from '@angular/core';

declare var jQuery: any;

@Component({
  selector: 'app-cashback',
  templateUrl: './cashback.component.html',
  styleUrls: ['./cashback.component.css']
})
export class CashbackComponent implements AfterViewInit {
  dom: any;
  model: any = {
    total: 0,
    items: []
  };

  constructor(private elementRef: ElementRef) {
  }

  ngAfterViewInit(): void {
    const nativeElement = this.elementRef.nativeElement;
    this.dom = nativeElement.firstChild;
  }

  show(): void {
    jQuery(this.dom).modal('show');
  }
}
