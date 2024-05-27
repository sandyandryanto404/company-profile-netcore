/**
 * This file is part of the Sandy Andryanto Company Profile Website.
 *
 * @author     Sandy Andryanto <sandy.andryanto404@gmail.com>
 * @copyright  2024
 *
 * For the full copyright and license information,
 * please view the LICENSE.md file that was distributed
 * with this source code.
 */

import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';
import { TooltipDirective } from '@babybeet/angular-tooltip';
import { CommonModule } from '@angular/common';
import { NgForm, FormsModule } from "@angular/forms"
import { AccountService } from './../../../services/account.service';
import { StorageService } from '../../../services/storage.service';

@Component({
  selector: 'app-password',
  standalone: true,
  imports: [RouterModule, TooltipDirective, CommonModule, FormsModule],
  templateUrl: './password.component.html',
  styles: ``
})
export class PasswordComponent implements OnInit {

  auth:boolean = false
  loading:boolean = true;
  title = environment.title;
  loadingSubmit:boolean = false;
  failed:boolean = false;
  messageFailed:string = ""
  messageSuccess:string = ""

  form: any = {
    current_password: null,
    password: null,
    password_confirm: null
  };

  constructor(private accountService: AccountService, private titleService:Title, private router: Router, private storageService: StorageService) {
    this.titleService.setTitle("Sign In | " + this.title);
  }

  ngOnInit(){
    setTimeout(() => {
       this.auth = this.storageService.isLoggedIn()
       if(!this.auth){
         this.router.navigate(['/auth/login']);
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
        oldPassword: form.value.current_password,
        newPassword: form.value.password,
        confirmNewPassword: form.value.password_confirm
      }
      this.accountService.passwordUpdate(formSubmit).subscribe({
        next: response => {
          setTimeout(() => {
            this.messageSuccess = response.message;
            this.loadingSubmit = false;
            this.failed = false;
            form.reset();
            form.controls['current_password'].setErrors(null);
            form.controls['password'].setErrors(null);
            form.controls['password_confirm'].setErrors(null);
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
