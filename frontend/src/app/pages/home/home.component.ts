import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Title } from "@angular/platform-browser";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styles: ``
})
export class HomeComponent implements OnInit {

  title = environment.title;
  loading:boolean = true;

  constructor(private titleService:Title) {
    this.titleService.setTitle("Home | " + this.title);
  }

  ngOnInit(): void {
      setTimeout(() => {
        this.loading = false
    }, 3000)
  }

}
