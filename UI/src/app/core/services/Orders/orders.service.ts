import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { OrderUpdateModel } from './models/OrderUpdate.model';
import { OrderCreateModel } from './models/OrderCreate.model';
import { GenericResponseModel } from '../GenericResponse.model';
import { OrderInfoModel } from './models/OrderInfo.model';

@Injectable({
  providedIn: 'root',
})
export class OrdersService {
  ApiBaseUrl = environment.apiBaseUrl + 'Orders';
  constructor(private http: HttpClient) {}

  //-----------------GET-----------------

  GetAllOrders(): Observable<GenericResponseModel<OrderInfoModel[]>> {
    return this.http.get<GenericResponseModel<OrderInfoModel[]>>(
      `${this.ApiBaseUrl}/GetAllOrders`
    );
  }

  GetAllOrdersByUserId(
    UserId: string
  ): Observable<GenericResponseModel<OrderInfoModel[]>> {
    return this.http.get<GenericResponseModel<OrderInfoModel[]>>(
      `${this.ApiBaseUrl}/GetAllOrdersByUserId/${UserId}`
    );
  }

  GetAllOrdersByShopId(
    ShopId: string
  ): Observable<GenericResponseModel<OrderInfoModel[]>> {
    return this.http.get<GenericResponseModel<OrderInfoModel[]>>(
      `${this.ApiBaseUrl}/GetAllOrdersByShopId/${ShopId}`
    );
  }

  GetOrderById(
    OrderId: string
  ): Observable<GenericResponseModel<OrderInfoModel>> {
    return this.http.get<GenericResponseModel<OrderInfoModel>>(
      `${this.ApiBaseUrl}/GetOrderById/${OrderId}`
    );
  }

  GetOrderByUserId(
    UserId: string
  ): Observable<GenericResponseModel<OrderInfoModel>> {
    return this.http.get<GenericResponseModel<OrderInfoModel>>(
      `${this.ApiBaseUrl}/GetOrderByUserId/${UserId}`
    );
  }

  GetActiveOrdersByUserId(
    UserId: string
  ): Observable<GenericResponseModel<OrderInfoModel[]>> {
    return this.http.get<GenericResponseModel<OrderInfoModel[]>>(
      `${this.ApiBaseUrl}/GetActiveOrdersByUserId/${UserId}`
    );
  }

  GetActiveOrdersByShopId(
    ShopId: string
  ): Observable<GenericResponseModel<OrderInfoModel[]>> {
    return this.http.get<GenericResponseModel<OrderInfoModel[]>>(
      `${this.ApiBaseUrl}/GetActiveOrdersByShopId/${ShopId}`
    );
  }
  //-----------------POST-----------------
  CreateOrder(UserId: string, model: OrderCreateModel): Observable<any> {
    return this.http.post<any>(
      `${this.ApiBaseUrl}/CreateOrder/${UserId}`,
      model
    );
  }
  //-----------------PUT-----------------
  UpdateOrder(OrderId: string, model: OrderUpdateModel): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateOrder/${OrderId}`,
      model
    );
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
