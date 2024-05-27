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
export class PortfolioService {

  constructor(private http: HttpClient) {}

  list(): Observable<any>{
    return this.http.get(environment.backendURL+"/portfolio/list", { headers: { Accept: 'application/json' } });
  }

  detail(id: number): Observable<any>{
    return this.http.get(environment.backendURL+"/portfolio/"+id, { headers: { Accept: 'application/json' } });
  }

}
