import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { GenericResponseModel } from '../GenericResponse.model';
import { ProductInfoModel } from './models/ProductInfo.model';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  ApiBaseUrl = environment.apiBaseUrl + 'Products';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------
  GetAllProducts(): Observable<GenericResponseModel<ProductInfoModel[]>> {
    return this.http.get<GenericResponseModel<ProductInfoModel[]>>(
      `${this.ApiBaseUrl}/GetAllProducts`
    );
  }
  GetProductsByShopId(
    ShopId: string
  ): Observable<GenericResponseModel<ProductInfoModel[]>> {
    return this.http.get<GenericResponseModel<ProductInfoModel[]>>(
      `${this.ApiBaseUrl}/GetProductsByShopId/${ShopId}`
    );
  }
  GetProductById(
    ProductId: string
  ): Observable<GenericResponseModel<ProductInfoModel>> {
    return this.http.get<GenericResponseModel<ProductInfoModel>>(
      `${this.ApiBaseUrl}/GetProductById/${ProductId}`
    );
  }
  GetProductsByName(
    ProductName: string
  ): Observable<GenericResponseModel<ProductInfoModel[]>> {
    return this.http.get<GenericResponseModel<ProductInfoModel[]>>(
      `${this.ApiBaseUrl}/GetProductsByName/${ProductName}`
    );
  }
  GetProductsByCategory(
    CategoryId: string
  ): Observable<GenericResponseModel<ProductInfoModel[]>> {
    return this.http.get<GenericResponseModel<ProductInfoModel[]>>(
      `${this.ApiBaseUrl}/GetProductsByCategory/${CategoryId}`
    );
  }
  GetProductsByCategoryName(
    CategoryName: string
  ): Observable<GenericResponseModel<ProductInfoModel[]>> {
    return this.http.get<GenericResponseModel<ProductInfoModel[]>>(
      `${this.ApiBaseUrl}/GetProductsByCategoryName/${CategoryName}`
    );
  }
  //-----------------POST-----------------
  CreateProduct(UserId: string, any: any): Observable<any> {
    return this.http.post<any>(
      `${this.ApiBaseUrl}/CreateProduct/${UserId}`,
      any
    );
  }

  //-----------------PUT-----------------

  UpdateProduct(ProductId: string, any: any): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateProduct/${ProductId}`,
      any
    );
  }
  ToggleProductStatus(ProductId: string, isActive: boolean): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/ToggleProductStatus/${ProductId}/${isActive}`,
      null
    );
  }

  //-----------------DELETE-----------------
  DeleteProduct(ProductId: string): Observable<any> {
    return this.http.delete<any>(
      `${this.ApiBaseUrl}/DeleteProduct/${ProductId}`
    );
  }
}
