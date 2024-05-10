import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class AuthorizeInterceptor implements HttpInterceptor {
  // CookieService'in enjekte edildiği yapılandırıcı
  constructor(private cookieService: CookieService) {}

  // HTTP isteğini onaylamak için kullanılan metod
  intercept(
    request: HttpRequest<unknown>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    var authToken = this.cookieService.get('Authorization');

    let authRequest = request;
    if (authToken) {
      authRequest = request.clone({
        setHeaders: {
          Authorization: authToken,
        },
      });
    }

    return next.handle(authRequest);
  }
}
