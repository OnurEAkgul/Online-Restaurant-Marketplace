import { Component, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CartItemsService } from 'src/app/core/services/CartItems/cart-items.service';
import { ProductsService } from 'src/app/core/services/Products/products.service';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';

@Component({
  selector: 'app-shop-page',
  templateUrl: './shop-page.component.html',
  styleUrls: ['./shop-page.component.css'],
})
export class ShopPageComponent {
  Products: any;
  ModalItems?: any;
  constructor(
    private productService: ProductsService,
    private shopService: ShopsService,
    private route: ActivatedRoute,
    private cartItemService: CartItemsService
  ) {}
  ShopId: any;
  InMaintenance: boolean = false;
  ShopInfo: any;
  itemQuantity: number = 0;
  ngOnInit() {
    this.GetShopId();
    console.log(this.ShopId);
    this.GetRestaurant();
    this.GetShopInformation(this.ShopId);
  }

  GetShopId() {
    this.route.paramMap.subscribe((response) => {
      if (response) {
        this.ShopId = response.get('ShopId');
      }
    });
  }

  GetShopInformation(ShopId: string) {
    this.shopService.GetShopById(this.ShopId).subscribe((response) => {
      this.ShopInfo = response;
      console.log(this.ShopInfo.data);
    });
  }

  GetRestaurant() {
    this.GetShopId();
    this.productService.GetProductsByShopId(this.ShopId).subscribe(
      (data) => {
        if (data) {
          this.Products = data;
          if (this.Products.data) {
            this.InMaintenance = false;
          }
          // this.Products.data.slice(0, 12);
          console.log(this.Products);
        }
      },
      (error) => {
        this.InMaintenance = true;
      }
    );
  }
  getSeverity(shops: any) {
    switch (shops.price) {
      case 'INSTOCK':
        return 'success';

      case 'LOWSTOCK':
        return 'warning';

      case 'OUTOFSTOCK':
        return 'danger';

      default:
        return null;
    }
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
    // console.log(this.basketItemId);
    // console.log(quantity);
    let model = { productId: this.ModalItems?.id, quantity: this.itemQuantity };
    console.log(model);
    this.cartItemService
      .AddCartItem('eb3f51e6-5b57-4314-ac08-af7cf2ec4ead', model)
      .subscribe((response) => {
        console.log(response);
      });
  }
}
