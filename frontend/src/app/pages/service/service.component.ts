import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Title } from "@angular/platform-browser";

@Component({
  selector: 'app-service',
  standalone: true,
  imports: [],
  templateUrl: './service.component.html',
  styles: ``
})
export class ServiceComponent implements OnInit {

  title = environment.title;

  constructor(private titleService:Title) {
    this.titleService.setTitle("Service | " + this.title);
  }

  ngOnInit(): void {
    
  }

}
