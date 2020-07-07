import {AfterViewInit, Component, ElementRef} from '@angular/core';

declare var jQuery: any;
@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.css']
})
export class ConfirmationComponent implements AfterViewInit {
  id: string;
  message: string;
  title: string;
  constructor(private elementRef: ElementRef ) { }
  ngAfterViewInit(): void {
    const nativeElement = this.elementRef.nativeElement;
    const child = nativeElement.firstChild;
    jQuery(child).on('hidden.bs.modal', () => {
      jQuery('.modal-backdrop').remove();
    });
  }
  confirm(): void {  }
}
