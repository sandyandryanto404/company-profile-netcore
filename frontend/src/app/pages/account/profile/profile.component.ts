import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { TooltipDirective } from '@babybeet/angular-tooltip';
import country from 'country-list-js';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [FormsModule, CommonModule, TooltipDirective],
  templateUrl: './profile.component.html',
  styles: ``
})
export class ProfileComponent implements OnInit {

  title = environment.title;
  auth:boolean = false;
  loading:boolean = true;
  countries:any
  image = 'https://dummyimage.com/150x150/343a40/6c757d'

  form: any = {
     gender: "",
     country: ""
  };

  constructor(private titleService:Title, private router: Router) {
    this.titleService.setTitle("Manage Profile | " + this.title);
  }

  ngOnInit(): void {
      setTimeout(() => {
        if(this.auth){
          this.countries = country.names().sort();
          this.loading = false
        }else{
          this.router.navigate(['/']);
        }
    }, 2000)
  }

}
