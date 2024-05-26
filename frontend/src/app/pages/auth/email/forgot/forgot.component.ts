import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { TooltipDirective } from '@babybeet/angular-tooltip';
import { CommonModule } from '@angular/common';
import { NgForm, FormsModule } from "@angular/forms"
import { AuthService } from '../../../../services/auth.service';
import { StorageService } from '../../../../services/storage.service';

@Component({
  selector: 'app-forgot',
  standalone: true,
  imports: [RouterModule, TooltipDirective, FormsModule, CommonModule],
  templateUrl: './forgot.component.html',
  styles: ``
})
export class ForgotComponent implements OnInit {

  title = environment.title;
  auth:boolean = false;
  loading:boolean = true;
  loadingSubmit:boolean = false;
  failed:boolean = false;
  messageFailed:string = ""
  messageSuccess:string = ""

  form: any = {
    email: null
  };

  constructor(private titleService:Title, private router: Router, private authService: AuthService, private storageService: StorageService) {
    this.titleService.setTitle("Forgot Password | " + this.title);
  }

  ngOnInit(){
    setTimeout(() => {
        this.auth = this.storageService.isLoggedIn()
        if(this.auth){
          this.router.navigate(['/']);
        }else{
          this.loading = false
        }
      }, 2000)
  }

  onSubmit(form: NgForm): void {
    this.messageSuccess = "";
    this.messageFailed = "";
    this.loadingSubmit = true;
    this.failed = false;
    this.authService.emailForgot(form.value).subscribe({
      next: response => {
        setTimeout(() => {
          let token = response.data;
          this.messageSuccess = response.message;
          this.loadingSubmit = false;
          this.failed = false;
          form.reset();
          form.controls['email'].setErrors(null);
          setTimeout(() => {
            this.router.navigate(['/auth/email/reset/'+token]);
          }, 2000)
        }, 2000)
      },
      error: err => {
        this.loadingSubmit = false;
        this.failed = true;
        this.messageFailed = err.error.message
      }
    });
  }

}
