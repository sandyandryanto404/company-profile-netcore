import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from  '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PortfolioService {

  constructor(private http: HttpClient) {}

  list(): Observable<any>{
    return this.http.get(environment.backendURL+"/portfolio/list", { headers: { Accept: 'application/json' } });
  }

  detail(id: number): Observable<any>{
    return this.http.get(environment.backendURL+"/portfolio/"+id, { headers: { Accept: 'application/json' } });
  }

}
