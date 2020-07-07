import {AfterViewInit, Component, ElementRef, OnInit} from '@angular/core';
import {Purchase} from '../../model/purchase';
declare var jQuery: any;
@Component({
  selector: 'app-purchase',
  templateUrl: './purchase.component.html',
  styleUrls: ['./purchase.component.css']
})
export class PurchaseComponent implements AfterViewInit {
  dom: any;
  model: Purchase = new Purchase();

  constructor(private elementRef: ElementRef) {  }

  ngAfterViewInit(): void {
    this.dom = this.elementRef.nativeElement.firstChild;
  }

  confirm(): void {

  }

  show(): void {
    jQuery(this.dom).modal('show');
  }
}
