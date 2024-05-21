import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductInfoModel } from 'src/app/core/services/Products/models/ProductInfo.model';
import { ProductsService } from 'src/app/core/services/Products/products.service';

@Component({
  selector: 'app-show-product',
  templateUrl: './show-product.component.html',
  styleUrls: ['./show-product.component.css'],
})
export class ShowProductComponent {
  products: ProductInfoModel[] = [];
  constructor(
    private productService: ProductsService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.GetShopId();
    this.GetProductTables();
  }

  shopId: any;
  GetShopId() {
    this.route.paramMap.subscribe(
      (response) => {
        this.shopId = response.get('ShopId');
      },
      (error) => {
        console.log(error);
      }
    );
  }

  GetProductTables() {
    this.productService
      .GetProductsByShopId(this.shopId)
      .subscribe((response) => {
        this.products = response.data;
      });
  }

  ProductUpdateStatus(ProductId: string, bool: boolean): void {
    this.productService
      .ToggleProductStatus(ProductId, bool)
      .subscribe((response) => {});
  }
}
