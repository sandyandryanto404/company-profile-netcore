import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Title } from "@angular/platform-browser";

@Component({
  selector: 'app-detail-article',
  standalone: true,
  imports: [],
  templateUrl: './detail.component.html',
  styles: ``
})
export class DetailComponent implements OnInit {

  title = environment.title;

  constructor(private titleService:Title) {
    this.titleService.setTitle("Article Details | " + this.title);
  }

  ngOnInit(): void {
   
  }

}