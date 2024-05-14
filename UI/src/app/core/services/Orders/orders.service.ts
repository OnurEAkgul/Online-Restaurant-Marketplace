import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  ApiBaseUrl = environment.apiBaseUrl + 'Orders';
  constructor(private http: HttpClient) {}

  //-----------------GET-----------------

  GetAllOrders(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetAllOrders`);
  }

  GetAllOrdersByUserId(UserId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetAllOrdersByUserId/${UserId}`
    );
  }

  GetAllOrdersByShopId(ShopId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetAllOrdersByShopId/${ShopId}`
    );
  }

  GetOrderById(OrderId: string): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetOrderById/${OrderId}`);
  }

  GetOrderByUserId(UserId: string): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetOrderByUserId/${UserId}`);
  }

  GetActiveOrdersByUserId(UserId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetActiveOrdersByUserId/${UserId}`
    );
  }

  GetActiveOrdersByShopId(ShopId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetActiveOrdersByShopId/${ShopId}`
    );
  }
  //-----------------POST-----------------
  CreateOrder(UserId: string, any: any): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/CreateOrder/${UserId}`, any);
  }
  //-----------------PUT-----------------
  UpdateOrder(OrderId: string, any: any): Observable<any> {
    return this.http.put<any>(`${this.ApiBaseUrl}/UpdateOrder/${OrderId}`, any);
  }
  UpdateOrderStatus(OrderId: string, isCompleted: boolean): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateOrderStatus/${OrderId}/${isCompleted}`,
      null
    );
  }
  //-----------------DELETE-----------------
  DeleteOrder(OrderId: string): Observable<any> {
    return this.http.delete<any>(`${this.ApiBaseUrl}/DeleteOrder/${OrderId}`);
  }
}
