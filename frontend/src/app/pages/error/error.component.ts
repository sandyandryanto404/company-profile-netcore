import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-error',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './error.component.html',
  styles: ``
})
export class ErrorComponent implements OnInit {

  title = environment.title;

  ngOnInit(): void {
    
  }

}
