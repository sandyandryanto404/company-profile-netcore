import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Title } from "@angular/platform-browser";

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [],
  templateUrl: './contact.component.html',
  styles: ``
})
export class ContactComponent implements OnInit {

  title = environment.title;
  loading:boolean = true;

  constructor(private titleService:Title) {
    this.titleService.setTitle("Contact | " + this.title);
  }

  ngOnInit(): void {
      setTimeout(() => {
        this.loading = false
    }, 3000)
  }

}
