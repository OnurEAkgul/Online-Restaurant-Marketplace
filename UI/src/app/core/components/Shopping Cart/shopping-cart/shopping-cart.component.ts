import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { ShoppingCartsService } from 'src/app/core/services/ShoppingCarts/shopping-carts.service';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.css'],
})
export class ShoppingCartComponent implements OnInit {
  constructor(
    private shoppingCartService: ShoppingCartsService,
    private userService: UserActionsService,
    private cookieService: CookieService,
    private router: Router
  ) {}
  ngOnInit() {
    this.GetUser();
    console.log(this.user);

    if (this.user) {
      console.log(this.user);
      this.getShoppingCart(this.user.nameid);
      if (this.flag == false) {
        this.router.navigateByUrl('Foods/Restaurants');
      }
    } else {
      this.router.navigateByUrl('Foods/Restaurants');
    }
  }

  flag: boolean = true;
  getShoppingCart(userId: string) {
    if (this.user.nameid) {
      this.shoppingCartService

        .GetShoppingCartByUserId(this.user.nameid)
        .subscribe(
          (response) => {
            if (response.data) {
              this.flag = true;
              console.log(this.flag);
              console.log(response);
              // this.router.navigateByUrl('Foods');
            }
          },
          (error) => {
            if (error.data == null) {
              this.flag = false;
              console.log(this.flag);
              console.log(error);
              this.router.navigateByUrl('Foods/Restaurants');
            }
          }
        );
    } else {
      console.log('else');
      this.router.navigateByUrl('Foods/Restaurants');
    }
  }
  user: any;
  GetUser() {
    console.log(this.user);
    let Token = this.cookieService.get('Authorization');
    if (Token) this.user = this.userService.TokenDecode(Token);
    console.log(this.user.nameid);
  }
}
