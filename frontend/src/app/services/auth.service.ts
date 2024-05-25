import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from  '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) {}

  login(data: any): Observable<any> {
    return this.http.post(environment.backendURL+"/auth/login", data, { headers: { Accept: 'application/json' } });
  }

  register(data: any): Observable<any> {
    return this.http.post(environment.backendURL+"/auth/register", data, { headers: { Accept: 'application/json' } });
  }

  confirm(token: string): Observable<any>{
    return this.http.get(environment.backendURL+"/auth/confirm/"+token, { headers: { Accept: 'application/json' } });
  }

  emailForgot(data: any): Observable<any> {
    return this.http.post(environment.backendURL+"/auth/email/forgot", data, { headers: { Accept: 'application/json' } });
  }

  emailReset(token: string, data: any): Observable<any> {
    return this.http.post(environment.backendURL+"/auth/email/reset/"+token, data, { headers: { Accept: 'application/json' } });
  }

}
