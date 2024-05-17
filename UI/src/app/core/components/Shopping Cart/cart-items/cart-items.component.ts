import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { CartItemsService } from 'src/app/core/services/CartItems/cart-items.service';
import { CartItemInfoModel } from 'src/app/core/services/CartItems/models/CartItemInfo.model';
import { ProductsService } from 'src/app/core/services/Products/products.service';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-cart-items',
  templateUrl: './cart-items.component.html',
  styleUrls: ['./cart-items.component.css'],
})
export class CartItemsComponent implements OnInit {
  ngOnInit() {
    this.getUserInfo();
    this.getCartItems();
    this.cdr.detectChanges();
  }
  totalPrice: number = 0;
  CartItems: CartItemInfoModel[] = [];

  constructor(
    private CartItemService: CartItemsService,
    private UserService: UserActionsService,
    private CookieService: CookieService,
    private ProductService: ProductsService,
    private router: Router,
    private cdr: ChangeDetectorRef
  ) {}
  UserInfo: any;
  ItemFlag: boolean = true;
  getUserInfo() {
    // console.log('thiss');
    this.UserInfo = this.UserService.TokenDecode(
      this.CookieService.get('Authorization')
    );
    // console.log(this.UserInfo);
  }
  getCartItems() {
    this.CartItemService.GetCartItemsByUserId(this.UserInfo.nameid).subscribe(
      (response) => {
        this.CartItems = response.data;
        // console.log(this.CartItems);
        this.GetTotalPrice();
      },
      (error) => {
        this.ItemFlag = false;
        this.router.navigateByUrl('Foods/Restaurants');
      }
    );
  }

  GetTotalPrice() {
    this.totalPrice = this.CartItems.reduce((sum: number, item: any) => {
      return sum + item.totalAmount;
    }, 0);

    // console.log('Total sum of totalAmount:', this.totalPrice);
  }

  removeItem(itemId: any) {
    // console.log(itemId);
    this.CartItemService.DeleteCartItem(itemId).subscribe(
      (response) => {
        this.getCartItems();
        // console.log('hererereree');
        // console.log(this.CartItems);
        if (this.CartItems == null) {
          this.router.navigateByUrl('Foods/Restaurants');
        }
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
