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
    return this.http.post(environment.backendURL+"/article/comments/"+id, { headers: this.authRequestHeader() });
  }

}
