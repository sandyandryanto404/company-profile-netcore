import { Component } from '@angular/core';
import { environment } from '../../../environments/environment';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';  

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './navigation.component.html',
  styles: ``
})
export class NavigationComponent {

    title = environment.title;
    auth:boolean = true;

    logout(): void {
      window.location.href = "/";
    }

}
