import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { GenericResponseModel } from '../GenericResponse.model';
import { TicketInfoModel } from './models/TicketInfo.model';
import { TicketCreate } from './models/TicketCreate.model';
import { TicketUpdateModel } from './models/TicketUpdate.model';

@Injectable({
  providedIn: 'root',
})
export class TicketsService {
  ApiBaseUrl = environment.apiBaseUrl + 'Tickets';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------
  GetAllTickets(): Observable<GenericResponseModel<TicketInfoModel[]>> {
    return this.http.get<GenericResponseModel<TicketInfoModel[]>>(
      `${this.ApiBaseUrl}/GetAllTickets`
    );
  }
  GetTicketsByStatus(
    status: boolean
  ): Observable<GenericResponseModel<TicketInfoModel[]>> {
    return this.http.get<GenericResponseModel<TicketInfoModel[]>>(
      `${this.ApiBaseUrl}/GetTicketsByStatus/${status}`
    );
  }
  GetActiveTickets(): Observable<GenericResponseModel<TicketInfoModel[]>> {
    return this.http.get<GenericResponseModel<TicketInfoModel[]>>(
      `${this.ApiBaseUrl}/GetActiveTickets`
    );
  }
  GetNotActiveTickets(): Observable<GenericResponseModel<TicketInfoModel[]>> {
    return this.http.get<GenericResponseModel<TicketInfoModel[]>>(
      `${this.ApiBaseUrl}/GetNotActiveTickets`
    );
  }
  GetTicketsBySupportUser(
    SupUserId: string
  ): Observable<GenericResponseModel<TicketInfoModel[]>> {
    return this.http.get<GenericResponseModel<TicketInfoModel[]>>(
      `${this.ApiBaseUrl}/GetTicketsBySupportUser/${SupUserId}`
    );
  }
  GetTicketsByCustomerUser(
    CustUserId: string
  ): Observable<GenericResponseModel<TicketInfoModel[]>> {
    return this.http.get<GenericResponseModel<TicketInfoModel[]>>(
      `${this.ApiBaseUrl}/GetTicketsByCustomerUser/${CustUserId}`
    );
  }
  GetTicketById(
    TicketId: string
  ): Observable<GenericResponseModel<TicketInfoModel>> {
    return this.http.get<GenericResponseModel<TicketInfoModel>>(
      `${this.ApiBaseUrl}/GetTicketById/${TicketId}`
    );
  }
  //-----------------POST-----------------
  CreateTicket(model: TicketCreate): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/CreateTicket`, model);
  } //-----------------PUT-----------------
  UpdateTicket(TicketId: string, model: TicketUpdateModel): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateTicket/${TicketId}`,
      model
    );
  }
  AssignSupportUser(TicketId: string, SupportUserId: string): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/AssignSupportUser/${TicketId}/${SupportUserId}`,
      null
    );
  }

  ToggleTicketStatus(TicketId: string, isActive: boolean): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/ToggleTicketStatus/${TicketId}/${isActive}`,
      null
    );
  }

  //-----------------DELETE-----------------
  DeleteTicket(TicketId: string): Observable<any> {
    return this.http.delete<any>(`${this.ApiBaseUrl}/DeleteTicket/${TicketId}`);
  }
}
