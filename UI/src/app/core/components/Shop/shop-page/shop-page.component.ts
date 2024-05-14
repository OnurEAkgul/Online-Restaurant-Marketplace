import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from 'src/app/core/services/Products/products.service';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';

@Component({
  selector: 'app-shop-page',
  templateUrl: './shop-page.component.html',
  styleUrls: ['./shop-page.component.css'],
})
export class ShopPageComponent {
  Products: any;
  constructor(
    private productService: ProductsService,
    private shopService: ShopsService,
    private route: ActivatedRoute
  ) {}
  ShopId: any;
  InMaintenance: boolean = false;
  ShopInfo: any;
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
}
