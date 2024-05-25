import { Component, OnInit } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { PageService } from "../../services/page.service"
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './about.component.html',
  styles: ``
})
export class AboutComponent implements OnInit {

  title = environment.title;
  loading:boolean = true;
  content:any

  constructor(private pageService: PageService, private titleService:Title, private router: Router) {
    this.titleService.setTitle("About | " + this.title);
  }

  ngOnInit(): void {
    this.pageService.ping().subscribe((response: any) => {
        this.loadContent()
    }, (error) => {
        console.log(error)
        this.router.navigate(['/unavailable']);
    });
  }

  loadContent(): void{
    this.pageService.about().subscribe((response: any) => {
        setTimeout(() => {
            this.content = response.data;
            this.loading = false;
        }, 1500)
    }, (error) => {
        console.log(error)
        this.router.navigate(['/unavailable']);
    });
  }

  getClasses(index:any): string{
      if(parseInt(index) <= 1){
        return "col mb-5 mb-5 mb-xl-0";
      }else if(parseInt(index) === 2){
        return "col mb-5 mb-5 mb-sm-0";
      }else{
        return "col mb-5";
      }
  }

}
