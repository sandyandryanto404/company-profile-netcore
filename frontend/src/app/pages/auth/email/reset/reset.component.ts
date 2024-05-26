import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { RouterModule, ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { TooltipDirective } from '@babybeet/angular-tooltip';
import { CommonModule } from '@angular/common';
import { NgForm, FormsModule } from "@angular/forms"
import { AuthService } from '../../../../services/auth.service';
import { StorageService } from '../../../../services/storage.service';

@Component({
  selector: 'app-reset',
  standalone: true,
  imports: [RouterModule, TooltipDirective, FormsModule, CommonModule],
  templateUrl: './reset.component.html',
  styles: ``
})
export class ResetComponent implements OnInit {

  title = environment.title;
  auth:boolean = false;
  loading:boolean = true;
  loadingSubmit:boolean = false;
  failed:boolean = false;
  messageFailed:string = ""
  messageSuccess:string = ""

  form: any = {
    email: null,
    password: null,
    password_confirm: null
  };

  constructor(private authService: AuthService, private storageService: StorageService, private titleService:Title, private router: Router, private route: ActivatedRoute) {
    this.titleService.setTitle("Reset Password | " + this.title);
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
    if(form.value.password != form.value.password_confirm){
      form.controls['password'].setErrors({ "confirmed": true });
    }else{
      this.messageSuccess = "";
      this.messageFailed = "";
      this.loadingSubmit = true;
      this.failed = false;
      let formSubmit = {
        email: form.value.email,
        password: form.value.password
      }
      let token = this.route.snapshot.params['token']
      this.authService.emailReset(token, formSubmit).subscribe({
        next: response => {
          setTimeout(() => {
            this.messageSuccess = response.message;
            this.loadingSubmit = false;
            this.failed = false;
            form.reset();
            form.controls['email'].setErrors(null);
            form.controls['password'].setErrors(null);
            form.controls['password_confirm'].setErrors(null);
            setTimeout(() => {
              this.router.navigate(['/auth/login']);
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

}
