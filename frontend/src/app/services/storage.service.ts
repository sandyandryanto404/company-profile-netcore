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

const USER_KEY = "token";

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  clean(): void {
    if (typeof window !== "undefined"){
      window.sessionStorage.clear();
    }
  }

  public saveUser(token: string): void {
    if (typeof window !== "undefined"){
      window.sessionStorage.removeItem(USER_KEY);
      window.sessionStorage.setItem(USER_KEY, token);
    }
  }

  public isLoggedIn(): boolean {
    if (typeof window !== "undefined"){
      const user = window.sessionStorage.getItem(USER_KEY);
      if (user) {
        return true;
      }
    }
    return false;
  }

}
