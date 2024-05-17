import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { CategoryCreateModel } from './models/CategoryCreate.model';
import { CategoryUpdateModel } from './models/CategoryUpdate.model';
import { GenericResponseModel } from '../GenericResponse.model';
import { CategoryInfoModel } from './models/CategoryInfo.model';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  ApiBaseUrl = environment.apiBaseUrl + 'Categories';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------

  GetAllCategories(): Observable<GenericResponseModel<CategoryInfoModel[]>> {
    return this.http.get<GenericResponseModel<CategoryInfoModel[]>>(
      `${this.ApiBaseUrl}/GetAllCategories`
    );
  }

  GetActiveCategories(): Observable<GenericResponseModel<CategoryInfoModel[]>> {
    return this.http.get<GenericResponseModel<CategoryInfoModel[]>>(
      `${this.ApiBaseUrl}/GetActiveCategories/`
    );
  }

  GetCategoryById(
    CategoryId: string
  ): Observable<GenericResponseModel<CategoryInfoModel>> {
    return this.http.get<GenericResponseModel<CategoryInfoModel>>(
      `${this.ApiBaseUrl}/GetCategoryById/${CategoryId}`
    );
  }
  GetCategoryByName(
    CategoryName: string
  ): Observable<GenericResponseModel<CategoryInfoModel>> {
    return this.http.get<GenericResponseModel<CategoryInfoModel>>(
      `${this.ApiBaseUrl}/GetCategoryByName/${CategoryName}`
    );
  }

  //-----------------POST-----------------
  CreateCategory(model: CategoryCreateModel): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/CreateCategory`, model);
  }

  //-----------------PUT-----------------
  UpdateCategory(
    CategoryId: string,
    model: CategoryUpdateModel
  ): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateCategory/${CategoryId}`,
      model
    );
  }

  ToggleCategoryStatus(
    CategoryId: string,
    ToggleStatus: boolean
  ): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/ToggleCategoryStatus/${CategoryId}/${ToggleStatus}`,
      null
    );
  }

  //-----------------DELETE-----------------
  DeleteCategory(CategoryId: string): Observable<any> {
    return this.http.delete<any>(
      `${this.ApiBaseUrl}/DeleteCategory/${CategoryId}`
    );
  }
}
