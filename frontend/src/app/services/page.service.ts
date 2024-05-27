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

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from  '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PageService {

  constructor(private http: HttpClient) {}

  ping(): Observable<any>{
    return this.http.get(environment.backendURL+"/page/ping", { headers: { Accept: 'application/json' } });
  }

  home(): Observable<any>{
    return this.http.get(environment.backendURL+"/page/home", { headers: { Accept: 'application/json' } });
  }

  about(): Observable<any>{
    return this.http.get(environment.backendURL+"/page/about", { headers: { Accept: 'application/json' } });
  }

  service(): Observable<any>{
    return this.http.get(environment.backendURL+"/page/service", { headers: { Accept: 'application/json' } });
  }

  faq(): Observable<any>{
    return this.http.get(environment.backendURL+"/page/faq", { headers: { Accept: 'application/json' } });
  }

  contact(): Observable<any>{
    return this.http.get(environment.backendURL+"/page/contact", { headers: { Accept: 'application/json' } });
  }

  message(data: any): Observable<any> {
    return this.http.post(environment.backendURL+"/page/message", data, { headers: { Accept: 'application/json' } });
  }

  subscribe(data: any): Observable<any> {
    return this.http.post(environment.backendURL+"/page/subscribe", data, { headers: { Accept: 'application/json' } });
  }

}
