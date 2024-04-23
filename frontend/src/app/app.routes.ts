import { Routes } from '@angular/router';
// General Pages
import { HomeComponent } from './pages/home/home.component';
import { AboutComponent } from './pages/about/about.component';
import { ServiceComponent } from './pages/service/service.component';
import { ListComponent as PortfolioList } from './pages/portfolio/list/list.component';
import { DetailComponent as PortfolioDetail } from './pages/portfolio/detail/detail.component';
import { ListComponent as ArticleList } from './pages/article/list/list.component';
import { DetailComponent as ArticleDetail } from './pages/article/detail/detail.component';
import { FaqComponent } from './pages/faq/faq.component';
import { ContactComponent } from './pages/contact/contact.component';
import { ErrorComponent } from './pages/error/error.component';
// Auth Pages
import { LoginComponent } from './pages/auth/login/login.component'
import { RegisterComponent } from './pages/auth/register/register.component'
import { ForgotComponent } from './pages/auth/email/forgot/forgot.component'
import { ResetComponent } from './pages/auth/email/reset/reset.component'
// Account Pages

export const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full'  },
    { path: 'about', component: AboutComponent},
    { path: 'service', component: ServiceComponent},
    { path: 'portfolio', component: PortfolioList},
    { path: 'portfolio/:id', component: PortfolioDetail},
    { path: 'article', component: ArticleList},
    { path: 'article/:slug', component: ArticleDetail},
    { path: 'faq', component: FaqComponent},
    { path: 'contact', component: ContactComponent},
    { path: 'auth/login', component: LoginComponent},
    { path: 'auth/register', component: RegisterComponent},
    { path: 'auth/email/forgot', component: ForgotComponent},
    { path: 'auth/email/reset/:token', component: ResetComponent},
    { path: '**', pathMatch: 'full', component: ErrorComponent }
];
