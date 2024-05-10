import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class CategoriesService {
  ApiBaseUrl = environment.apiBaseUrl + 'Categories';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------

  GetAllCategories(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetAllCategories`);
  }

  GetActiveCategories(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetActiveCategories/`);
  }

  GetCategoryById(CategoryId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetCategoryById/${CategoryId}`
    );
  }
  GetCategoryByName(CategoryName: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetCategoryByName/${CategoryName}`
    );
  }

  //-----------------POST-----------------
  CreateCategory(any: any): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/CreateCategory`, any);
  }

  //-----------------PUT-----------------
  UpdateCategory(CategoryId: string, any: any): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateCategory/${CategoryId}`,
      any
    );
  }

  ToggleCategoryStatus(
    CategoryId: string,
    ToggleStatus: boolean
  ): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/ToggleCategoryStatus/${CategoryId}`,
      ToggleStatus
    );
  }

  //-----------------DELETE-----------------
  DeleteCategory(CategoryId: string): Observable<any> {
    return this.http.delete<any>(
      `${this.ApiBaseUrl}/DeleteCategory/${CategoryId}`
    );
  }
}
