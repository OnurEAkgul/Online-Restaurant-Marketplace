import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ShoppingCartsService {
  ApiBaseUrl = environment.apiBaseUrl + 'ShoppingCarts';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------
  GetAllShoppingCarts(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetAllShoppingCarts`);
  }
  GetShoppingCartById(ShoppingCartId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetShoppingCartById/${ShoppingCartId}`
    );
  }
  GetShoppingCartByUserId(UserId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetShoppingCartByUserId/${UserId}`
    );
  }
  //-----------------POST-----------------
  CreateShoppingCart(UserId: string, any: any): Observable<any> {
    return this.http.post<any>(
      `${this.ApiBaseUrl}/CreateShoppingCart/${UserId}`,
      any
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
