import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { CategoriesService } from 'src/app/core/services/Categories/categories.service';
import { CategoryInfoModel } from 'src/app/core/services/Categories/models/CategoryInfo.model';
import { ProductUpdateModel } from 'src/app/core/services/Products/models/ProductUpdate.model';
import { ProductsService } from 'src/app/core/services/Products/products.service';
import { ShopsService } from 'src/app/core/services/Shops/shops.service';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css'],
})
export class UpdateProductComponent implements OnInit {
  ProductModel: ProductUpdateModel;
  CategoryModel: CategoryInfoModel[] = [];
  DropdownModel: any[] = [];
  CategoryId: any;

  constructor(
    private productService: ProductsService,
    private categoryService: CategoriesService,
    private userService: UserActionsService,
    private cookieService: CookieService,
    private shopService: ShopsService,
    private route: ActivatedRoute
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
    this.GetProductId();
    this.GetCategories();
  }

  ProductId: any;

  GetProductId() {
    this.route.paramMap.subscribe(
      (params) => {
        this.ProductId = params.get('ProductId');
        if (this.ProductId) {
          this.GetProduct();
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }

  GetProduct() {
    this.productService.GetProductById(this.ProductId).subscribe(
      (response) => {
        this.ProductModel = response.data;
        this.CategoryId = this.ProductModel.categoryId; // Set the initial category ID
        console.log(this.ProductModel);
      },
      (error) => {
        console.error(error);
      }
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

        // Set the selected category once DropdownModel is populated
        if (this.ProductModel.categoryId) {
          const selectedCategory = this.DropdownModel.find(
            (category) => category.value === this.ProductModel.categoryId
          );
          if (selectedCategory) {
            this.CategoryId = selectedCategory.value;
          }
        }
      },
      (error) => {
        console.error(error);
      }
    );
  }

  UpdateProduct() {
    this.ProductModel.categoryId = this.CategoryId;
    this.productService
      .UpdateProduct(this.ProductId, this.ProductModel)
      .subscribe(
        (response) => {
          console.log(response);
        },
        (error) => {
          console.error(error);
        }
      );
  }
}
