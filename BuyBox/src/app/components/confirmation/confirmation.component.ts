import {AfterViewInit, Component, ElementRef} from '@angular/core';

declare var jQuery: any;

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.css']
})
export class ConfirmationComponent implements AfterViewInit {
  dom: any;
  message: string;
  title: string;

  constructor(private elementRef: ElementRef) {  }

  ngAfterViewInit(): void {
    this.dom = this.elementRef.nativeElement.firstChild;
  }

  show(): void {
    jQuery(this.dom).modal('show');
  }

  confirm(): void {
  }
}
