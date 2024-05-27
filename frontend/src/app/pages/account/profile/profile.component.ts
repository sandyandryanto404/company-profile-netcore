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
import { FormGroup, FormControl, Validators } from '@angular/forms';
import country from 'country-list-js';

@Component({
  selector: 'app-profile',
  standalone: true,
  imports: [RouterModule, TooltipDirective, CommonModule, FormsModule],
  templateUrl: './profile.component.html',
  styles: ``
})
export class ProfileComponent implements OnInit {

  auth:boolean = false
  loading:boolean = true;
  title = environment.title;
  loadingUpload:boolean = false;
  loadingSubmit:boolean = false;
  failed:boolean = false;
  messageFailed:string = ""
  messageSuccess:string = ""
  countries:any
  image = 'https://dummyimage.com/150x150/343a40/6c757d'


  form: any = {
    aboutMe:"",
    address:"",
    country:"",
    email:"",
    firstName:"",
    gender:"",
    lastName:"",
    phone:""
  };

  myForm = new FormGroup({
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  });

  constructor(private accountService: AccountService, private titleService:Title, private router: Router, private storageService: StorageService) {
    this.titleService.setTitle("Manage Profile | " + this.title);
  }

  ngOnInit(){
    setTimeout(() => {
       this.auth = this.storageService.isLoggedIn()
       if(!this.auth){
         this.router.navigate(['/auth/login']);
       }else{
          this.loadContent()
       }
    }, 2000)
 }

 loadContent(): void{
  this.accountService.profileDetail().subscribe({
    next: response => {
      setTimeout(() => {
        let countries = country.names().sort()
        let user = response.data

        if(user.image){
          this.image = environment.backendURL+"/Uploads/"+user.image
        }

        this.countries = countries
        this.form.aboutMe = user.aboutMe
        this.form.address = user.address
        this.form.country = user.country
        this.form.email = user.email
        this.form.firstName = user.firstName
        this.form.gender = user.gender
        this.form.lastName = user.lastName
        this.form.phone = user.phone
        this.loading = false;
      }, 2000)
    },
    error: err => {
      this.router.navigate(['/auth/login']);
    }
  });
 }

 onSubmit(form: NgForm): void {

    this.messageSuccess = "";
    this.messageFailed = "";
    this.loadingSubmit = true;
    this.failed = false;

    this.accountService.profileUpdate(form.value).subscribe({
      next: response => {
        setTimeout(() => {
          this.loadingSubmit = false;
          this.failed = false;
          this.messageSuccess = response.message;
          setTimeout(() => {
            this.loading = true;
            this.loadContent()
          }, 1500)

        }, 2000)
      },
      error: err => {
        this.loadingSubmit = false;
        this.failed = true;
        this.messageFailed = err.error.message
      }
    });
 }

  onChange(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.myForm.patchValue({
        fileSource: file
      });
      const formData = new FormData();
      const fileSourceValue = this.myForm.get('fileSource')?.value;
      if (fileSourceValue !== null && fileSourceValue !== undefined) {
          formData.append('file', fileSourceValue);
          this.loadingUpload = true;
          this.accountService.profileUpload(formData).subscribe({
            next: response => {
               setTimeout(() => {
                  this.loadingUpload = false;
                  this.image = environment.backendURL+"/"+response.fileName
               }, 2000)
            },
            error: err => {
              this.loadingUpload = false;
              this.failed = true;
              console.log(err)
            }
          });
      }
    }
  }

}
