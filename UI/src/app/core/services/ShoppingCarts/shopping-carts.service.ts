import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { GenericResponseModel } from '../GenericResponse.model';
import { ShoppingCartModel } from './models/ShoppingCartInfo.model';

@Injectable({
  providedIn: 'root',
})
export class ShoppingCartsService {
  ApiBaseUrl = environment.apiBaseUrl + 'ShoppingCarts';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------
  GetAllShoppingCarts(): Observable<GenericResponseModel<ShoppingCartModel[]>> {
    return this.http.get<GenericResponseModel<ShoppingCartModel[]>>(
      `${this.ApiBaseUrl}/GetAllShoppingCarts`
    );
  }
  GetShoppingCartById(
    ShoppingCartId: string
  ): Observable<GenericResponseModel<ShoppingCartModel>> {
    return this.http.get<GenericResponseModel<ShoppingCartModel>>(
      `${this.ApiBaseUrl}/GetShoppingCartById/${ShoppingCartId}`
    );
  }
  GetShoppingCartByUserId(
    UserId: string
  ): Observable<GenericResponseModel<ShoppingCartModel>> {
    return this.http.get<GenericResponseModel<ShoppingCartModel>>(
      `${this.ApiBaseUrl}/GetShoppingCartByUserId/${UserId}`
    );
  }
  //-----------------POST-----------------
  CreateShoppingCart(UserId: string): Observable<any> {
    return this.http.post<any>(
      `${this.ApiBaseUrl}/CreateShoppingCart/${UserId}`,
      null
    );
  }
  //-----------------PUT-----------------
  UpdateShopInfo(ShoppingCartId: string, UserId: string): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateShopInfo/${ShoppingCartId}`,
      UserId
    );
  }
  //-----------------DELETE-----------------
  DeleteShoppingCart(ShoppingCartId: string): Observable<any> {
    return this.http.delete<any>(
      `${this.ApiBaseUrl}/DeleteShoppingCart/${ShoppingCartId}`
    );
  }
}
