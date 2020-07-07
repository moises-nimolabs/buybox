import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-confirmation',
  templateUrl: './confirmation.component.html',
  styleUrls: ['./confirmation.component.css']
})
export class ConfirmationComponent implements OnInit {
  id: string;
  message: string;
  title: string;
  constructor() { }
  ngOnInit(): void { }
  confirm(): void {  }
}
