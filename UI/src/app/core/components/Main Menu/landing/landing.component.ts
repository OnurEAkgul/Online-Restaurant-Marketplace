import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { LayoutService } from 'src/app/core/layout/service/app.layout.service';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css'],
})
export class LandingComponent implements OnInit {
  constructor(
    private cookieService: CookieService,
    private router: Router,
    private userService: UserActionsService
  ) {}
  ngOnInit() {
    this.checkLogin();
  }

  User: any;
  checkLogin() {
    this.User = this.cookieService.get('Authorization');
    if (this.User) {
      this.router.navigateByUrl('/Foods/Restaurants');
    }
  }

  UserLogout() {
    this.userService.Logout();
  }
}
