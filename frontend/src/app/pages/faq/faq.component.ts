import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Title } from "@angular/platform-browser";

@Component({
  selector: 'app-faq',
  standalone: true,
  imports: [],
  templateUrl: './faq.component.html',
  styles: ``
})
export class FaqComponent implements OnInit {

  title = environment.title;
  loading:boolean = true;

  constructor(private titleService:Title) {
    this.titleService.setTitle("FAQ | " + this.title);
  }

  ngOnInit(): void {
      setTimeout(() => {
        this.loading = false
    }, 3000)
  }

}
