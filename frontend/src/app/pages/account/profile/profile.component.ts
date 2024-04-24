import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { Router } from '@angular/router';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [],
  templateUrl: './profile.component.html',
  styles: ``
})
export class ProfileComponent implements OnInit {

  title = environment.title;
  auth:boolean = false;
  loading:boolean = false;
  countries:any
  image = 'https://dummyimage.com/150x150/343a40/6c757d'

  constructor(private titleService:Title, private router: Router) {
    this.titleService.setTitle("Manage Profile | " + this.title);
  }

  ngOnInit(): void {
      setTimeout(() => {
        if(this.auth){
          this.loading = false
        }else{
          this.router.navigate(['/']);
        }
    }, 2000)
  }

}
