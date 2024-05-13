import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { LayoutService } from './service/app.layout.service';
import { UserActionsService } from '../services/UserActions/user-actions.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-topbar',
  templateUrl: './app.topbar.component.html',
})
export class AppTopBarComponent implements OnInit {
  items!: MenuItem[];

  @ViewChild('menubutton') menuButton!: ElementRef;

  @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

  @ViewChild('topbarmenu') menu!: ElementRef;

  constructor(
    public layoutService: LayoutService,
    private userService: UserActionsService,
    private cookieService: CookieService
  ) {}
  ngOnInit(): void {
    // this.writetoconsole();
  }
  user: any;
  onConfigButtonClick() {
    this.layoutService.showConfigSidebar();
  }

  UserLogout() {
    this.userService.Logout();
  }

  writetoconsole() {
    this.user = this.userService.TokenDecode(
      this.cookieService.get('Authorization')
    );
    console.log(this.user);
  }
}
