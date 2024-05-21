//MODULES
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { BrowserModule } from '@angular/platform-browser';
import { AppLayoutModule } from './core/layout/app.layout.module';
import { AppRoutingModule } from './app-routing.module';
import { CheckboxModule } from 'primeng/checkbox';
import { InputMaskModule } from 'primeng/inputmask';
import { TableModule } from 'primeng/table';
import { DataViewModule } from 'primeng/dataview';
import { TagModule } from 'primeng/tag';
import { TabMenuModule } from 'primeng/tabmenu';
import { BadgeModule } from 'primeng/badge';
import { TabViewModule } from 'primeng/tabview';
import { FieldsetModule } from 'primeng/fieldset';
import { DialogModule } from 'primeng/dialog';
import { DividerModule } from 'primeng/divider';
import { PasswordModule } from 'primeng/password';

//UTILS
import { MessageService } from 'primeng/api';
import { AuthorizeInterceptor } from './core/interceptors/authorize.interceptor';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

//COMPONENTS
import { AppComponent } from './app.component';
import { SignUpComponent } from './core/components/Authorization/sign-up/sign-up.component';
import { LoginComponent } from './core/components/Authorization/login/login.component';
import { LandingComponent } from './core/components/Main Menu/landing/landing.component';
import { FAQComponent } from './core/components/Agreements/faq/faq.component';
import { KVKKComponent } from './core/components/Agreements/kvkk/kvkk.component';
import { PrivacyComponent } from './core/components/Agreements/privacy/privacy.component';
import { TosComponent } from './core/components/Agreements/tos/tos.component';
import { MenuComponent } from './core/components/Main Menu/menu/menu.component';
import { CookiesComponent } from './core/components/Agreements/cookies/cookies.component';
import { OperationGuideComponent } from './core/components/Agreements/operation-guide/operation-guide.component';
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
import { NotfoundComponent } from './core/components/Error Pages/Not Found/notfound.component';
import { MaintenanceComponent } from './core/components/Error Pages/maintenance/maintenance.component';
import { DropdownModule } from 'primeng/dropdown';

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
    MaintenanceComponent,
    LandingComponent,
    FAQComponent,
    KVKKComponent,
    PrivacyComponent,
    TosComponent,
    CookiesComponent,
    OperationGuideComponent,
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
    DataViewModule,
    TagModule,
    TabMenuModule,
    BadgeModule,
    TabViewModule,
    FieldsetModule,
    DialogModule,
    DividerModule,
    PasswordModule,
    DropdownModule,
  ],
  providers: [
    MessageService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
