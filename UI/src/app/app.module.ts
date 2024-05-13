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
import { TableModule } from 'primeng/table';
import { MessageService } from 'primeng/api';
import { AuthorizeInterceptor } from './core/interceptors/authorize.interceptor';
import { MenuComponent } from './core/components/Main Menu/menu/menu.component';
import { ShoppingCartComponent } from './core/components/Shopping Cart/shopping-cart/shopping-cart.component';
import { CreateShopComponent } from './core/components/Shop/create-shop/create-shop.component';
import { ShopPageComponent } from './core/components/Shop/shop-page/shop-page.component';
import { UpdateShopComponent } from './core/components/Shop/update-shop/update-shop.component';
import { ProfileComponent } from './core/components/Profile/profile/profile.component';
import { ProfileUpdateComponent } from './core/components/Profile/profile-update/profile-update.component';
import { CartItemsComponent } from './core/components/Shopping Cart/cart-items/cart-items.component';
import { AddProductComponent } from './core/components/Products/add-product/add-product.component';
import { UpdateProductComponent } from './core/components/Products/update-product/update-product.component';
import { ShowProductComponent } from './core/components/Products/show-product/show-product.component';
import { OrdersComponent } from './core/components/Orders/orders/orders.component';
import { PastOrdersComponent } from './core/components/Orders/past-orders/past-orders.component';
import { ShopOwnerRegisterComponent } from './core/components/Authorization/shop-owner-register/shop-owner-register.component';
import { SupportRegisterComponent } from './core/components/Authorization/support-register/support-register.component';
import { AdminTablesComponent } from './core/components/Admin/admin-tables/tables.component';
import { OperationsComponent } from './core/components/Admin/operations/operations.component';
import { NotfoundComponent } from './core/components/Not Found/notfound.component';

@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    LoginComponent,
    MenuComponent,
    ShoppingCartComponent,
    CreateShopComponent,
    ShopPageComponent,
    UpdateShopComponent,
    ProfileComponent,
    ProfileUpdateComponent,
    CartItemsComponent,
    AddProductComponent,
    UpdateProductComponent,
    ShowProductComponent,
    OrdersComponent,
    PastOrdersComponent,
    ShopOwnerRegisterComponent,
    SupportRegisterComponent,
    AdminTablesComponent,
    OperationsComponent,
    NotfoundComponent,
  ],
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
    TableModule,
  ],
  providers: [
    MessageService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
