import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { MessageService } from 'primeng/api';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-create-shop',
  templateUrl: './create-shop.component.html',
  styleUrls: ['./create-shop.component.css'],
})
export class CreateShopComponent {
  signupmodel: any;
  shopmodel: any;
  loginmodel: any;
  constructor(
    private userService: UserActionsService,
    private shopService: ShopsService,
    private cookieService: CookieService,
    private router: Router
  ) {
    this.signupmodel = {
      email: '',
      password: '',
      username: '',
      phoneNumber: '',
    };
    this.shopmodel = {
      name: '',
      description: '',
      location: '',
      contactEmail: '',
      contactPhone: '',
    };
    this.loginmodel = {
      email: '',
      password: '',
      username: '',
    };
  }
  userInfo: any;
  SignUp() {
    console.log(this.signupmodel);
    this.userService.ShopOwnerSignUp(this.signupmodel).subscribe(
      (response) => {
        this.loginmodel.email = this.signupmodel.email;
        this.loginmodel.password = this.signupmodel.password;
        this.loginmodel.username = this.signupmodel.username;

        this.userService.Login(this.loginmodel).subscribe(
          (response) => {
            console.log(response);
            console.log(response.token);
            this.userService.SaveToCookies(response.token);
            let tokenResponse = this.userService.TokenDecode(
              this.cookieService.get('Authorization')
            );

            this.userInfo = tokenResponse;

            // console.log(this.signupmodel);
            console.log(this.userInfo.nameid);
            console.log(this.shopmodel);
            this.ShopCreate(this.userInfo.nameid, this.shopmodel);
            this.router.navigateByUrl('/Foods');
          },
          (error) => {
            console.log(error);
            return;
          }
        );
      },
      (error) => {
        console.log(error);
        return;
      }
    );
  }

  ShopCreate(userId: string, model: any) {
    console.log(this.shopmodel);
    this.shopService.CreateNewShop(userId, model).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
