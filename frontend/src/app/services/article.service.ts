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
export class ArticleService {

  constructor(private http: HttpClient) {}

  public authRequestHeader(): any {
      let token = window.sessionStorage.getItem("token");
      return {
        "Content-Type": "application/json",
        "Authorization": "Bearer "+token
      }
  }

  list(params: any): Observable<any>{
    return this.http.get(environment.backendURL+"/article/list?"+params, { headers: { Accept: 'application/json' } });
  }

  detail(slug: string): Observable<any>{
    return this.http.get(environment.backendURL+"/article/detail/"+slug, { headers: { Accept: 'application/json' } });
  }

  commentList(id: number): Observable<any>{
    return this.http.get(environment.backendURL+"/article/comments/"+id, { headers: { Accept: 'application/json' } });
  }

  commentCreate(id: number, data: any): Observable<any>{
    return this.http.post(environment.backendURL+"/article/comments/"+id, data, { headers: this.authRequestHeader() });
  }

}
