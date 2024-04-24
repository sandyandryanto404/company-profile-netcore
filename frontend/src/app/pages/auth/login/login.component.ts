import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { TooltipDirective } from '@babybeet/angular-tooltip';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterModule, TooltipDirective],
  templateUrl: './login.component.html',
  styles: ``
})
export class LoginComponent implements OnInit {

  auth:boolean = false;
  loading:boolean = true;
  title = environment.title;

  constructor(private titleService:Title, private router: Router) {
    this.titleService.setTitle("Sign In | " + this.title);
  }

  ngOnInit(): void {
      setTimeout(() => {
        if(!this.auth){
          this.loading = false
        }else{
          this.router.navigate(['/']);
        }
    }, 2000)
  }

}
