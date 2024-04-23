import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [],
  templateUrl: './contact.component.html',
  styles: ``
})
export class ContactComponent implements OnInit {

  title = environment.title;

  ngOnInit(): void {
   
  }

}
