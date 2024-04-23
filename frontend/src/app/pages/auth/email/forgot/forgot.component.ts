import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-forgot',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './forgot.component.html',
  styles: ``
})
export class ForgotComponent implements OnInit {

  title = environment.title;
  auth:boolean = false;
  loading:boolean = false;

  constructor(private titleService:Title, private router: Router) {
    this.titleService.setTitle("Forgot Password | " + this.title);
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
