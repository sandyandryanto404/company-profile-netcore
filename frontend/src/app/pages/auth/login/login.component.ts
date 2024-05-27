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
import { AuthService } from '../../../services/auth.service';
import { StorageService } from '../../../services/storage.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterModule, TooltipDirective, CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styles: ``
})
export class LoginComponent implements OnInit {

  auth:boolean = false
  loading:boolean = true;
  title = environment.title;
  loadingSubmit:boolean = false;
  failed:boolean = false;
  messageFailed:string = ""
  messageSuccess:string = ""

  form: any = {
    email: null,
    password: null
  };

  constructor(private authService: AuthService, private titleService:Title, private router: Router, private storageService: StorageService) {
    this.titleService.setTitle("Sign In | " + this.title);
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

    this.authService.login(form.value).subscribe({
      next: response => {
        let token = response.token
        setTimeout(() => {
          this.loadingSubmit = false;
          this.failed = false;
          form.reset();
          form.controls['email'].setErrors(null);
          form.controls['password'].setErrors(null);
          this.storageService.saveUser(token)

          setTimeout(() => {
            window.location.href = "/"
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
