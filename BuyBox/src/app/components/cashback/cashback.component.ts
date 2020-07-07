import { Component, OnInit } from '@angular/core';
import {TokenCollection} from '../../model/token-collection';

@Component({
  selector: 'app-cashback',
  templateUrl: './cashback.component.html',
  styleUrls: ['./cashback.component.css']
})
export class CashbackComponent implements OnInit {
  model: any = {
    total: 0,
    items: []
  };
  constructor() { }

  ngOnInit(): void {
  }

}
