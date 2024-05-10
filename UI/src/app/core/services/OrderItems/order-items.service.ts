import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class OrderItemsService {
  ApiBaseUrl = environment.apiBaseUrl + 'OrderItems';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------

  GetAllOrderItems(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetAllOrderItems`);
  }

  GetOrderItemsByOrderId(OrderId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetOrderItemsByOrderId/${OrderId}`
    );
  }

  GetOrderItemById(OrderItemId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetOrderItemById/${OrderItemId}`
    );
  }

  //-----------------POST-----------------
  AddOrderItem(any: any): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/AddOrderItem`, any);
  }
  //-----------------PUT-----------------
  UpdateOrderItem(OrderItemId: string, any: any): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateOrderItem/${OrderItemId}`,
      any
    );
  }

  //-----------------DELETE-----------------
  DeleteOrderItem(OrderItemsId: string): Observable<any> {
    return this.http.delete<any>(
      `${this.ApiBaseUrl}/DeleteOrderItem/${OrderItemsId}`
    );
  }
}
