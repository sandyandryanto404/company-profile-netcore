import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { PageService } from "../../services/page.service"
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgForm, FormsModule } from "@angular/forms"

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './contact.component.html',
  styles: ``
})
export class ContactComponent implements OnInit {

  title = environment.title;
  loading:boolean = true;
  loadingSubmit:boolean = false;
  messageSuccess:string = ""
  failed:boolean = false
  content:any

  form: any = {
    name: null,
    subject: null,
    message: null,
    email: null
  };

  constructor(private pageService: PageService, private titleService:Title, private router: Router) {
    this.titleService.setTitle("Contact | " + this.title);
  }

  ngOnInit(): void {
    this.pageService.ping().subscribe((response: any) => {
        this.loadContent( )
    }, (error) => {
        console.log(error)
        this.router.navigate(['/unavailable']);
    });
  }

  loadContent(): void{
    this.pageService.contact().subscribe((response: any) => {
        setTimeout(() => {
            this.content = response.data;
            this.loading = false;
        }, 1500)
    }, (error) => {
        console.log(error)
        this.router.navigate(['/unavailable']);
    });
  }


  onSubmit(form: NgForm): void {

    this.messageSuccess = "";
    this.loadingSubmit = true;
    this.failed = false;

    this.pageService.message(form.value).subscribe({
      next: data => {
        setTimeout(() => {

          this.loadingSubmit = false;
          this.failed = false;
          this.messageSuccess = 'Your message has been sent. Thank you!'
          form.reset();
          form.controls['name'].setErrors(null);
          form.controls['email'].setErrors(null);
          form.controls['subject'].setErrors(null);
          form.controls['message'].setErrors(null);

        }, 2000)
      },
      error: err => {
        this.loadingSubmit = false;
        this.failed = true;
        console.log(err.error.message)
      }
    });

  }

}
