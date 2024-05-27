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
import { environment } from '../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { PageService } from "../../services/page.service"
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NgForm, FormsModule } from "@angular/forms"
import moment from "moment"

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule],
  templateUrl: './home.component.html',
  styles: ``
})
export class HomeComponent implements OnInit {

  title = environment.title;
  loading:boolean = true;
  loadingSubmit:boolean = false;
  message:string = ""
  failed:boolean = false
  content:any

  form: any = {
    email: null
  };

  constructor(private pageService: PageService, private titleService:Title, private router: Router) {
    this.titleService.setTitle("Home | " + this.title);
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
    this.pageService.home().subscribe((response: any) => {
        setTimeout(() => {
            this.content = response.data;
            this.loading = false;
        }, 1500)
    }, (error) => {
        console.log(error)
        this.router.navigate(['/unavailable']);
    });
  }

  dateConvert(datetime:any): string{
    return moment(datetime).format("MMMM DD, Y HH:mm:ss");
  }

  onSubmit(form: NgForm): void {

    this.loadingSubmit = true;
    this.message = "";
    this.failed = false;
    const { email } = this.form;

    this.pageService.subscribe({ email: email }).subscribe({
      next: data => {
        this.loadingSubmit = false;
        this.failed = false;
        this.message = 'Thank for subscribing to our newsletter.'
        form.reset();
        form.controls['email'].setErrors(null);
      },
      error: err => {
        this.loadingSubmit = false;
        this.failed = true;
        this.message = err.error.message;
      }
    });
  }

}
