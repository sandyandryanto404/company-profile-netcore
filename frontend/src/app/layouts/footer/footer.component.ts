import { Component } from '@angular/core';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [],
  templateUrl: './footer.component.html',
  styles: ``
})
export class FooterComponent {

  title = environment.title;
  nowYear = new Date().getFullYear();

}
