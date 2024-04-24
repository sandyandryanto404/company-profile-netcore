import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { Router } from '@angular/router';

@Component({
  selector: 'app-password',
  standalone: true,
  imports: [],
  templateUrl: './password.component.html',
  styles: ``
})
export class PasswordComponent implements OnInit {

  title = environment.title;
  auth:boolean = false;
  loading:boolean = false;

  constructor(private titleService:Title, private router: Router) {
    this.titleService.setTitle("Change Password | " + this.title);
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
