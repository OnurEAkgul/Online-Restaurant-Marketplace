import { AppComponent } from './app.component';
import { SignUpComponent } from './core/components/Authorization/sign-up/sign-up.component';
import { LoginComponent } from './core/components/Authorization/login/login.component';

import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppLayoutModule } from './core/layout/app.layout.module';
import { AppRoutingModule } from './app-routing.module';
import { CheckboxModule } from 'primeng/checkbox';
import { InputMaskModule } from 'primeng/inputmask';
import { MessageService } from 'primeng/api';
import { AuthorizeInterceptor } from './core/interceptors/authorize.interceptor';

@NgModule({
  declarations: [AppComponent, SignUpComponent, LoginComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    AppLayoutModule,
    CheckboxModule,
    ButtonModule,
    InputTextModule,
    InputMaskModule,
    HttpClientModule,
  ],
  providers: [
    MessageService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
