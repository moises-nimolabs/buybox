import {ApiService} from './services/api.service';
import {Component, OnInit, ViewChild} from '@angular/core';

declare var jQuery: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private api: ApiService) {  }
  ngOnInit(): void {
    this.api.sessionHead();
  }
}
