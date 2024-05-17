import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { OrderItemCreateModel } from './models/OrderItemCreate.model';
import { OrderItemUpdateModel } from './models/OrderItemUpdate.model';
import { OrderItemResponseModel } from './models/OrderItemResponse.model';

@Injectable({
  providedIn: 'root',
})
export class OrderItemsService {
  ApiBaseUrl = environment.apiBaseUrl + 'OrderItems';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------

  GetAllOrderItems(): Observable<OrderItemResponseModel> {
    return this.http.get<OrderItemResponseModel>(
      `${this.ApiBaseUrl}/GetAllOrderItems`
    );
  }

  GetOrderItemsByOrderId(OrderId: string): Observable<OrderItemResponseModel> {
    return this.http.get<OrderItemResponseModel>(
      `${this.ApiBaseUrl}/GetOrderItemsByOrderId/${OrderId}`
    );
  }

  GetOrderItemById(OrderItemId: string): Observable<OrderItemResponseModel> {
    return this.http.get<OrderItemResponseModel>(
      `${this.ApiBaseUrl}/GetOrderItemById/${OrderItemId}`
    );
  }

  //-----------------POST-----------------
  AddOrderItem(model: OrderItemCreateModel): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/AddOrderItem`, model);
  }
  //-----------------PUT-----------------
  UpdateOrderItem(
    OrderItemId: string,
    model: OrderItemUpdateModel
  ): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateOrderItem/${OrderItemId}`,
      model
    );
  }

  //-----------------DELETE-----------------
  DeleteOrderItem(OrderItemsId: string): Observable<any> {
    return this.http.delete<any>(
      `${this.ApiBaseUrl}/DeleteOrderItem/${OrderItemsId}`
    );
  }
}
