import { Component, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { CartItemsService } from 'src/app/core/services/CartItems/cart-items.service';
import { ProductInfoModel } from 'src/app/core/services/Products/models/ProductInfo.model';
import { ProductsService } from 'src/app/core/services/Products/products.service';
import { ShopInfoModel } from 'src/app/core/services/Shops/models/ShopInfo.model';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';
import { TokenModel } from 'src/app/core/services/UserActions/models/Token.model';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-shop-page',
  templateUrl: './shop-page.component.html',
  styleUrls: ['./shop-page.component.css'],
})
export class ShopPageComponent {
  Products: ProductInfoModel[] = [];
  ModalItems?: ProductInfoModel;

  constructor(
    private productService: ProductsService,
    private shopService: ShopsService,
    private route: ActivatedRoute,
    private cartItemService: CartItemsService,
    private UserService: UserActionsService,
    private CookieService: CookieService,
    private router: Router
  ) {
    this.ShopInfo = {
      contactEmail: '',
      contactPhone: '',
      description: '',
      id: '',
      isOpen: false,
      location: '',
      logoUrl: '',
      name: '',
    };
  }

  ShopId: any;
  InMaintenance: boolean = false;
  ShopInfo: ShopInfoModel;
  itemQuantity: number = 0;

  ngOnInit() {
    this.GetShopId();
    // console.log(this.ShopId);
    this.GetRestaurant();
    this.GetShopInformation(this.ShopId);
    this.getUserInfo();
  }

  GetShopId() {
    this.route.paramMap.subscribe((response) => {
      if (response) {
        this.ShopId = response.get('ShopId');
      }
    });
  }

  GetShopInformation(ShopId: string) {
    this.shopService.GetShopById(this.ShopId).subscribe(
      (response) => {
        this.ShopInfo = response.data;
        // console.log(this.ShopInfo);
      },
      (error) => {
        this.ShopInfo = error.data;
      }
    );
  }

  GetRestaurant() {
    this.GetShopId();
    this.productService.GetProductsByShopId(this.ShopId).subscribe(
      (data) => {
        if (data) {
          this.Products = data.data;
          if (this.Products) {
            this.InMaintenance = false;
          }
          // this.Products.data.slice(0, 12);
          console.log(this.Products);
        }
      },
      (error) => {
        this.Products = error.data;
        this.InMaintenance = true;
      }
    );
  }

  visible: boolean = false;
  ShowDialog(product: any) {
    console.log(product);
    let ItemId: string = product.id;
    this.basketItemId = ItemId;
    this.ModalItems = product;
    product.itemQuantity = 0;
    // console.log(product.itemQuantity);
    this.itemQuantity = product.itemQuantity + 1;
    this.visible = true;
  }

  basketItemId: string = '';
  AddToBasket(quantity: number) {
    console.log(this.UserInfo.nameid);
    // console.log(this.basketItemId);
    // console.log(quantity);
    let model = { productId: this.ModalItems?.id, quantity: this.itemQuantity };
    console.log(model);
    this.cartItemService
      .AddCartItem(this.UserInfo.nameid, model)
      .subscribe((response) => {
        console.log(response);
      });

    this.visible = !this.visible;
  }

  UserInfo: any;
  getUserInfo() {
    // console.log('thiss');
    this.UserInfo = this.UserService.TokenDecode(
      this.CookieService.get('Authorization')
    );
    console.log(this.UserInfo);
  }

  RouteToUpdate() {
    console.log(this.ShopId);
    this.router.navigateByUrl(`/Foods/UpdateShop/${this.ShopId}`);
  }
  RouteToProducts() {
    console.log(this.ShopId);
    this.router.navigateByUrl(`/Foods/ShowProducts/${this.ShopId}`);
  }
}
