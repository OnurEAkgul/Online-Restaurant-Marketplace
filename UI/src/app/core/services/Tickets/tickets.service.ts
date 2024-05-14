import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class TicketsService {
  ApiBaseUrl = environment.apiBaseUrl + 'Tickets';
  constructor(private http: HttpClient) {}
  //-----------------GET-----------------
  GetAllTickets(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetAllTickets`);
  }

  GetTicketsByStatus(status: boolean): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetTicketsByStatus/${status}`
    );
  }
  GetActiveTickets(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetActiveTickets`);
  }
  GetNotActiveTickets(): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetNotActiveTickets`);
  }
  GetTicketsBySupportUser(SupUserId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetTicketsBySupportUser/${SupUserId}`
    );
  }
  GetTicketsByCustomerUser(CustUserId: string): Observable<any> {
    return this.http.get<any>(
      `${this.ApiBaseUrl}/GetTicketsByCustomerUser/${CustUserId}`
    );
  }
  GetTicketById(TicketId: string): Observable<any> {
    return this.http.get<any>(`${this.ApiBaseUrl}/GetTicketById/${TicketId}`);
  }
  //-----------------POST-----------------
  CreateTicket(any: any): Observable<any> {
    return this.http.post<any>(`${this.ApiBaseUrl}/CreateTicket`, any);
  } //-----------------PUT-----------------
  UpdateTicket(TicketId: string, any: any): Observable<any> {
    return this.http.put<any>(
      `${this.ApiBaseUrl}/UpdateTicket/${TicketId}`,
      any
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
