import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Title } from "@angular/platform-browser";

@Component({
  selector: 'app-list-article',
  standalone: true,
  imports: [],
  templateUrl: './list.component.html',
  styles: ``
})
export class ListComponent implements OnInit {

  title = environment.title;

  constructor(private titleService:Title) {
    this.titleService.setTitle("Article | " + this.title);
  }

  ngOnInit(): void {
   
  }

}
