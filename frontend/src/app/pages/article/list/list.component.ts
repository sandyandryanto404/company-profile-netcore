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
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ArticleService } from '../../../services/article.service';
import { PageService } from '../../../services/page.service';
import moment from "moment"
@Component({
  selector: 'app-list-article',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './list.component.html',
  styles: ``
})
export class ListComponent implements OnInit {

  title = environment.title;
  loading:boolean = true;
  message:string = ""
  failed:boolean = false
  content:any
  continue:boolean = false

  constructor(private articleService: ArticleService, private pageService: PageService, private titleService:Title, private router: Router) {
    this.titleService.setTitle("Article | " + this.title);
  }


  ngOnInit(): void {
    this.pageService.ping().subscribe((response: any) => {

        if (typeof window !== "undefined"){
          let page = window.sessionStorage.getItem('page');
          if(!page){
            window.sessionStorage.setItem("page", "1");
          }
        }

        this.loadContent()
    }, (error) => {
        console.log(error)
        this.router.navigate(['/unavailable']);
    });
  }

  loadContent(): void{
    var params:any = {}

    if (typeof window !== "undefined"){
      let page = window.sessionStorage.getItem('page');
      if(page){
        params["page"] = page;
      }
    }

    var queryString = Object.keys(params).map(key => key + '=' + params[key]).join('&');
    this.articleService.list(queryString).subscribe((response: any) => {
        setTimeout(() => {
            this.content = response.data;
            this.continue = response.data.continue
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

  loadMore(): void{
    if (typeof window !== "undefined"){
      let page = window.sessionStorage.getItem('page');
      if(page){
        let nextPage = parseInt(page) + 1
        window.sessionStorage.setItem("page", nextPage.toString());
      }
      this.loading = true;
      setTimeout(() => {
         this.loadContent()
      }, 2000)
    }
  }

}
