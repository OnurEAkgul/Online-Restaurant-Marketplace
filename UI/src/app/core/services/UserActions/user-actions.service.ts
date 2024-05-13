import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class UserActionsService {
  ApiBaseUrl = environment.apiBaseUrl + 'UserActions';

  constructor(private http: HttpClient, private cookieService: CookieService) {}

  //-----------------GET-----------------
  GetAllUsers(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetAllUsers`);
  }

  GetUser(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetUser`);
  }

  GetAllUsersByRole(role: string): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetAllUsersByRole`, {
      params: { Role: role ?? '' },
    });
  }
  GetUserInfoById(id: string): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetUserInfoById/${id}`);
  }

  //-----------------POST-----------------

  Login(any: any): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/Login`, any);
  }

  SignUp(any: any): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/SignUp`, any);
  }
  ShopOwnerSignUp(any: any): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/ShopOwnerSignUp`, any);
  }
  SupportUserRegister(any: any): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/SupportUserRegister`, any);
  }

  //-----------------PUT-----------------
  UpdateUserInfo(id: string, any: any): Observable<any> {
    return this.http.put<any>(`${this.ApiBaseUrl}/UpdateUserInfo/${id}`, any);
  }

  //-----------------DELETE-----------------
  UserDelete(id: string): Observable<any> {
    return this.http.delete<any>(`${this.ApiBaseUrl}/UserDelete/${id}`);
  }

  //-----------------LOCAL ACITONS-----------------
  SaveToCookies(token: string) {
    this.cookieService.set('Authorization', token);
  }

  Logout() {
    this.cookieService.delete('Authorization');
  }

  TokenDecode(EncodedToken: string) {
    let DecodedToken = jwtDecode(EncodedToken);
    return DecodedToken;
  }
}
