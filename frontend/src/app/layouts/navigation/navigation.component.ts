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

import { Component } from '@angular/core';
import { environment } from '../../../environments/environment';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { StorageService } from '../../services/storage.service';

@Component({
  selector: 'app-navigation',
  standalone: true,
  imports: [RouterModule, CommonModule],
  templateUrl: './navigation.component.html',
  styles: ``
})
export class NavigationComponent {

    title = environment.title;
    auth:boolean = false;

    constructor(private storageService: StorageService) { }

    ngAfterContentInit (){
      this.auth = this.storageService.isLoggedIn()
    }

    logout(): void {
      this.storageService.clean()
      setTimeout(() => {
        window.location.href = "/";
      }, 2000)
    }

}
