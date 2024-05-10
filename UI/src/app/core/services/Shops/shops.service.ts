import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class ShopsService {
  ApiBaseUrl = environment.apiBaseUrl + 'Shops';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------
  GetShops(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetShops`);
  }
  GetOpenShops(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetOpenShops`);
  }
  GetShopsByName(name: string): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetShopsByName`, {
      params: { Name: name ?? '' },
    });
  }
  GetShopById(ShopId: string): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetShopById/${ShopId}`);
  }
  //-----------------POST-----------------
  CreateNewShop(any: any): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/CreateNewShop`, any);
  }
  //-----------------PUT-----------------
  UpdateShopInfo(ShopId: string, any: any): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateShopInfo/${ShopId}`,
      any
    );
  }
  OpenCloseShop(ShopId: string, Status: boolean): Observable<any> {
    return this.http.put<any>(`${this.ApiBaseUrl}/OpenCloseShop/${ShopId}`, {
      params: { ToggleStatus: Status ?? '' },
    });
  }
  //-----------------DELETE-----------------
  RemoveShop(ShopId: string): Observable<any> {
    return this.http.delete<any>(`${this.ApiBaseUrl}/RemoveShop/${ShopId}`);
  }
}
