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
  loadingSubmit:boolean = false;
  failed:boolean = false;
  messageFailed:string = ""
  messageSuccess:string = ""
  countries:any
  image = 'https://dummyimage.com/150x150/343a40/6c757d'

  form: any = {
     gender: "",
     country: ""
  };

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

 }

}
