import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { CategoriesService } from 'src/app/core/services/Categories/categories.service';
import { CategoryInfoModel } from 'src/app/core/services/Categories/models/CategoryInfo.model';
import { ProductCreateModel } from 'src/app/core/services/Products/models/ProductCreate.model';
import { ProductsService } from 'src/app/core/services/Products/products.service';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
})
export class AddProductComponent implements OnInit {
  ProductModel: ProductCreateModel;
  CategoryModel: CategoryInfoModel[] = [];
  DropdownModel: any[] = [];
  CategoryId: any;
  constructor(
    private productService: ProductsService,
    private categoryService: CategoriesService,
    private userService: UserActionsService,
    private cookieService: CookieService,
    private shopService: ShopsService
  ) {
    this.ProductModel = {
      categoryId: '',
      description: '',
      imageUrl: '',
      isActive: false,
      name: '',
      price: 0,
      shopId: '',
    };
  }

  ngOnInit() {
    this.GetCategories();
    this.GetUserInfo();
    this.GetShopInfo();
  }
  User: any;

  GetUserInfo() {
    this.User = this.userService.TokenDecode(
      this.cookieService.get('Authorization')
    );
    console.log(this.User);
  }

  GetShopInfo() {
    this.shopService.GetShopByShopOwnerId(this.User.nameid).subscribe(
      (response) => {
        this.ProductModel.shopId = response.data.id;
        // console.log(response.data.id);
      },
      (error) => {}
    );
  }

  GetCategories() {
    this.categoryService.GetActiveCategories().subscribe(
      (response) => {
        this.CategoryModel = response.data;
        this.DropdownModel = this.CategoryModel.map((category) => ({
          label: category.name, // Assuming 'name' is a property of CategoryInfoModel
          value: category.id, // Assuming 'id' is a property of CategoryInfoModel
        }));
        // console.log(response);
      },
      (error) => {}
    );
  }
  AddProduct() {
    this.ProductModel.categoryId = this.CategoryId.value;
    // console.log(this.ProductModel.categoryId);
    this.productService.CreateProduct(this.ProductModel).subscribe(
      (response) => {
        console.log(response);
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
