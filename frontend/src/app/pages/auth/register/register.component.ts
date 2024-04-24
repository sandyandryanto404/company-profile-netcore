import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { TooltipDirective } from '@babybeet/angular-tooltip';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [RouterModule, TooltipDirective],
  templateUrl: './register.component.html',
  styles: ``
})
export class RegisterComponent implements OnInit {

  title = environment.title;
  auth:boolean = false;
  loading:boolean = true;

  constructor(private titleService:Title, private router: Router) {
    this.titleService.setTitle("Sign Up | " + this.title);
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
