import { Component, OnInit } from '@angular/core';
import { environment } from '../../../../environments/environment';
import { Title } from "@angular/platform-browser";
import { PageService } from "../../../services/page.service"
import { PortfolioService } from "../../../services/portfolio.service"
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-list-portfolio',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './list.component.html',
  styles: ``
})
export class ListComponent implements OnInit {

  title = environment.title;
  loading:boolean = true;
  content:any

  constructor(private pageService: PageService, private portfolioService: PortfolioService,  private titleService:Title, private router: Router) {
    this.titleService.setTitle("Portfolio | " + this.title);
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
    this.portfolioService.list().subscribe((response: any) => {
        setTimeout(() => {
            this.content = response.data;
            this.loading = false;
        }, 1500)
    }, (error) => {
        console.log(error)
        this.router.navigate(['/unavailable']);
    });
  }

}
