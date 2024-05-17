import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { GenericResponseModel } from '../GenericResponse.model';
import { CartItemInfoModel } from './models/CartItemInfo.model';

@Injectable({
  providedIn: 'root',
})
export class CartItemsService {
  ApiBaseUrl = environment.apiBaseUrl + 'CartItems';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------

  GetAllCartItems(): Observable<GenericResponseModel<CartItemInfoModel[]>> {
    return this.http.get<GenericResponseModel<CartItemInfoModel[]>>(
      `${this.ApiBaseUrl}/GetAllCartItems`
    );
  }

  GetCartItemById(
    ItemId: string
  ): Observable<GenericResponseModel<CartItemInfoModel>> {
    return this.http.get<GenericResponseModel<CartItemInfoModel>>(
      `${this.ApiBaseUrl}/GetCartItemById/${ItemId}`
    );
  }
  GetCartItemsByShoppingCartId(
    ShoppingCartId: string
  ): Observable<GenericResponseModel<CartItemInfoModel[]>> {
    return this.http.get<GenericResponseModel<CartItemInfoModel[]>>(
      `${this.ApiBaseUrl}/GetCartItemsByShoppingCartId/${ShoppingCartId}`
    );
  }
  GetCartItemsByUserId(
    UserId: string
  ): Observable<GenericResponseModel<CartItemInfoModel[]>> {
    return this.http.get<GenericResponseModel<CartItemInfoModel[]>>(
      `${this.ApiBaseUrl}/GetCartItemsByUserId/${UserId}`
    );
  }

  //-----------------POST-----------------
  AddCartItem(UserId: string, model: any): Observable<any> {
    return this.http.post<any>(
      `${this.ApiBaseUrl}/AddCartItem/${UserId}`,
      model
    );
  }

  //-----------------PUT-----------------
  UpdateCartItems(
    ShoppingCartId: string,
    ItemId: string,
    any: any
  ): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateCartItems/${ShoppingCartId}/${ItemId}`,
      any
    );
  }

  //-----------------DELETE-----------------
  DeleteCartItem(ItemId: string): Observable<any> {
    return this.http.delete<any>(`${this.ApiBaseUrl}/DeleteCartItem/${ItemId}`);
  }
}
