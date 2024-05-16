import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { MessageService } from 'primeng/api';
import { ShopCreateModel } from 'src/app/core/services/Shops/models/ShopCreate.model';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';
import { LoginRequestModel } from 'src/app/core/services/UserActions/models/LoginRequest.model';
import { SignUpModel } from 'src/app/core/services/UserActions/models/SignUp.model';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-create-shop',
  templateUrl: './create-shop.component.html',
  styleUrls: ['./create-shop.component.css'],
})
export class CreateShopComponent {
  SignUpModel: SignUpModel;
  ShopModel: ShopCreateModel;
  loginmodel: LoginRequestModel;
  constructor(
    private userService: UserActionsService,
    private shopService: ShopsService,
    private cookieService: CookieService,
    private router: Router
  ) {
    this.SignUpModel = {
      email: '',
      password: '',
      username: '',
      phoneNumber: '',
    };
    this.ShopModel = {
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
      rememberMe: false,
    };
  }
  userInfo: any;
  SignUp() {
    console.log(this.SignUpModel);
    this.userService.ShopOwnerSignUp(this.SignUpModel).subscribe(
      (response) => {
        this.loginmodel.email = this.SignUpModel.email;
        this.loginmodel.password = this.SignUpModel.password;
        this.loginmodel.username = this.SignUpModel.username;

        this.userService.Login(this.loginmodel).subscribe(
          (response) => {
            console.log(response);
            console.log(response.token);
            this.userService.SaveToCookies(response.token);
            let tokenResponse = this.userService.TokenDecode(
              this.cookieService.get('Authorization')
            );

            this.userInfo = tokenResponse;

            // console.log(this.SignUpModel);
            console.log(this.userInfo.nameid);
            console.log(this.ShopModel);
            this.ShopCreate(this.userInfo.nameid, this.ShopModel);
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
    console.log(this.ShopModel);
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
