import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ArticleService } from '../../../services/article.service';
import { PageService } from '../../../services/page.service';
import moment from "moment"
@Component({
  selector: 'app-list-article',
  standalone: true,
  imports: [],
  templateUrl: './list.component.html',
  styles: ``
})
export class ListComponent implements OnInit {

  title = environment.title;
  loading:boolean = true;
  message:string = ""
  failed:boolean = false
  content:any

  constructor(private articleService: ArticleService, private pageService: PageService, private titleService:Title, private router: Router) {
    this.titleService.setTitle("Article | " + this.title);
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
    var params:any = {}
    var queryString = Object.keys(params).map(key => key + '=' + params[key]).join('&');
    this.articleService.list(queryString).subscribe((response: any) => {
        setTimeout(() => {
            console.log(response.data)
            this.content = response.data;
            this.loading = false;
        }, 1500)
    }, (error) => {
        console.log(error)
        this.router.navigate(['/unavailable']);
    });
  }

}
