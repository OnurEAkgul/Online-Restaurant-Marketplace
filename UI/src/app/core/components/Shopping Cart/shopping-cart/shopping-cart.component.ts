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
    this.getShoppingCart(this.user.nameid);
    if (this.flag == false) {
      this.router.navigateByUrl('');
    }
  }

  flag: boolean = true;
  getShoppingCart(userId: string) {
    this.shoppingCartService
      .GetShoppingCartByUserId(this.user.nameid)
      .subscribe(
        (response) => {
          if (response.data) {
            this.flag = true;
            console.log(this.flag);
            console.log(response);
          }
        },
        (error) => {
          if (error.data == null) {
            this.flag = false;
            console.log(this.flag);
            console.log(error);
            this.router.navigateByUrl('');
          }
        }
      );
  }
  user: any;
  GetUser() {
    let Token = this.cookieService.get('Authorization');
    this.user = this.userService.TokenDecode(Token);
  }
}
