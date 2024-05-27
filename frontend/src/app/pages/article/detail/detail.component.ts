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
import { RouterModule, ActivatedRoute } from '@angular/router';
import { ArticleService } from '../../../services/article.service';
import { PageService } from '../../../services/page.service';
import { StorageService } from '../../../services/storage.service';
import { CommentComponent } from './../../../layouts/comment/comment.component';
import { NgForm, FormsModule } from "@angular/forms"
import moment from "moment"

@Component({
  selector: 'app-detail-article',
  standalone: true,
  imports: [CommonModule, RouterModule, CommentComponent, FormsModule],
  templateUrl: './detail.component.html',
  styles: ``
})
export class DetailComponent implements OnInit {

  auth:boolean = false
  title = environment.title;
  loading:boolean = true;
  loadingComment:boolean = true;
  loadingSubmit:boolean = false;
  message:string = ""
  failed:boolean = false
  content:any
  comments:any

  form: any = {
    comment: null
  };

  constructor(private articleService: ArticleService, private pageService: PageService, private titleService:Title, private router: Router, private route: ActivatedRoute, private storageService: StorageService) {
    this.titleService.setTitle("Article Details | " + this.title);
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
    let slug = this.route.snapshot.params['slug']
    this.articleService.detail(slug).subscribe((response: any) => {
        setTimeout(() => {
            this.auth = this.storageService.isLoggedIn()
            this.content = response.data;
            this.loading = false;
            this.loadComment()
        }, 1500)
    }, (error) => {
        console.log(error)
        this.router.navigate(['/unavailable']);
    });
  }

  loadComment(): void{
     let article_id = this.content.id
     this.articleService.commentList(article_id).subscribe((response: any) => {
      setTimeout(() => {
          this.comments = response.data.comments;
          this.loadingComment = false;
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

    let article_id = this.content.id
    this.loadingSubmit = true;
    this.failed = false;

    this.articleService.commentCreate(article_id, form.value).subscribe({
      next: data => {
        setTimeout(() => {
          this.loadingSubmit = false;
          this.failed = false;
          form.reset();
          form.controls['comment'].setErrors(null);
          this.loadComment()
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
