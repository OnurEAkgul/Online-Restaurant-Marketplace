import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { GenericResponseModel } from '../GenericResponse.model';
import { ShopInfoModel } from './models/ShopInfo.model';
import { ShopCreateModel } from './models/ShopCreate.model';
import { ShopUpdateModel } from './models/ShopUpdate.model';

@Injectable({
  providedIn: 'root',
})
export class ShopsService {
  ApiBaseUrl = environment.apiBaseUrl + 'Shops';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------
  GetShops(): Observable<GenericResponseModel<ShopInfoModel[]>> {
    return this.http.get<GenericResponseModel<ShopInfoModel[]>>(
      `${this.ApiBaseUrl}/GetShops`
    );
  }
  GetOpenShops(): Observable<GenericResponseModel<ShopInfoModel[]>> {
    return this.http.get<GenericResponseModel<ShopInfoModel[]>>(
      `${this.ApiBaseUrl}/GetOpenShops`
    );
  }
  GetShopsByName(
    name: string
  ): Observable<GenericResponseModel<ShopInfoModel[]>> {
    return this.http.get<GenericResponseModel<ShopInfoModel[]>>(
      `${this.ApiBaseUrl}/GetShopsByName`,
      {
        params: { Name: name ?? '' },
      }
    );
  }
  GetShopById(ShopId: string): Observable<GenericResponseModel<ShopInfoModel>> {
    return this.http.get<GenericResponseModel<ShopInfoModel>>(
      `${this.ApiBaseUrl}/GetShopById/${ShopId}`
    );
  }
  //-----------------POST-----------------
  CreateNewShop(userId: string, model: ShopCreateModel): Observable<any> {
    return this.http.post<any>(
      `${this.ApiBaseUrl}/CreateNewShop/${userId}`,
      model
    );
  }
  //-----------------PUT-----------------
  UpdateShopInfo(ShopId: string, model: ShopUpdateModel): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateShopInfo/${ShopId}`,
      model
    );
  }
  OpenCloseShop(ShopId: string, Status: boolean): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/OpenCloseShop/${ShopId}/${Status}`,
      null
    );
  }
  //-----------------DELETE-----------------
  RemoveShop(ShopId: string): Observable<any> {
    return this.http.delete<any>(`${this.ApiBaseUrl}/RemoveShop/${ShopId}`);
  }
}
