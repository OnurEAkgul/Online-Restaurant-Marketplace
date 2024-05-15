import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class CartItemsService {
  ApiBaseUrl = environment.apiBaseUrl + 'CartItems';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------

  GetAllCartItems(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetAllCartItems`);
  }

  GetCartItemById(ItemId: string): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetCartItemById/${ItemId}`);
  }
  GetCartItemsByShoppingCartId(ShoppingCartId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetCartItemsByShoppingCartId/${ShoppingCartId}`
    );
  }
  GetCartItemsByUserId(UserId: string): Observable<any> {
    return this.http.get<any>(
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