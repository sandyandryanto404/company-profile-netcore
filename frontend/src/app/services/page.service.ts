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

}
