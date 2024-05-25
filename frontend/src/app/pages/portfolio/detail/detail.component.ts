import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { PageService } from "../../../services/page.service"
import { PortfolioService } from "../../../services/portfolio.service"
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RouterModule, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-detail-portfolio',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './detail.component.html',
  styles: ``
})
export class DetailComponent implements OnInit {

  title = environment.title;
  loading:boolean = true;
  content:any

  constructor(private pageService: PageService, private portfolioService: PortfolioService,  private titleService:Title, private router: Router, private route: ActivatedRoute) {
    this.titleService.setTitle("Portfolio Details | " + this.title);
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
    let id = this.route.snapshot.params['id']
    this.portfolioService.detail(id).subscribe((response: any) => {
        setTimeout(() => {
            this.content = response.data;
            this.loading = false;
        }, 1500)
    }, (error) => {
        this.router.navigate(['/unavailable']);
    });
  }

}
