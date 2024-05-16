import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { GenericResponseModel } from '../GenericResponse.model';
import { UserInfoModel } from './models/UserInfo.model';
import { LoginResponseModel } from './models/LoginResponse.model';
import { LoginRequestModel } from './models/LoginRequest.model';
import { SignUpModel } from './models/SignUp.model';
import { UserUpdateModel } from './models/UserUpdate.model';

@Injectable({
  providedIn: 'root',
})
export class UserActionsService {
  ApiBaseUrl = environment.apiBaseUrl + 'UserActions';

  constructor(private http: HttpClient, private cookieService: CookieService) {}

  //-----------------GET-----------------
  GetAllUsers(): Observable<GenericResponseModel<UserInfoModel[]>> {
    return this.http.get<GenericResponseModel<UserInfoModel[]>>(
      `${this.ApiBaseUrl}/GetAllUsers`
    );
  }

  GetUser(): Observable<GenericResponseModel<UserInfoModel>> {
    return this.http.get<GenericResponseModel<UserInfoModel>>(
      `${this.ApiBaseUrl}/GetUser`
    );
  }

  GetAllUsersByRole(
    role: string
  ): Observable<GenericResponseModel<UserInfoModel[]>> {
    return this.http.get<GenericResponseModel<UserInfoModel[]>>(
      `${this.ApiBaseUrl}/GetAllUsersByRole`,
      {
        params: { Role: role ?? '' },
      }
    );
  }
  GetUserInfoById(id: string): Observable<GenericResponseModel<UserInfoModel>> {
    return this.http.get<GenericResponseModel<UserInfoModel>>(
      `${this.ApiBaseUrl}/GetUserInfoById/${id}`
    );
  }

  //-----------------POST-----------------

  Login(model: LoginRequestModel): Observable<LoginResponseModel> {
    return this.http.post<LoginResponseModel>(
      `${this.ApiBaseUrl}/Login`,
      model
    );
  }

  SignUp(any: SignUpModel): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/SignUp`, any);
  }
  ShopOwnerSignUp(any: SignUpModel): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/ShopOwnerSignUp`, any);
  }
  SupportUserRegister(any: SignUpModel): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/SupportUserRegister`, any);
  }

  //-----------------PUT-----------------
  UpdateUserInfo(id: string, any: UserUpdateModel): Observable<any> {
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
