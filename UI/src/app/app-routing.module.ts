import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppLayoutComponent } from './core/layout/app.layout.component';
import { AppComponent } from './app.component';
import { SignUpComponent } from './core/components/Authorization/sign-up/sign-up.component';
import { LoginComponent } from './core/components/Authorization/login/login.component';
import { authGuard } from './core/guards/auth.guard';
import { MenuComponent } from './core/components/Main Menu/menu/menu.component';
import { ShopOwnerRegisterComponent } from './core/components/Authorization/shop-owner-register/shop-owner-register.component';
import { NotfoundComponent } from './core/components/Error Pages/Not Found/notfound.component';
import { ShopPageComponent } from './core/components/Shop/shop-page/shop-page.component';
import { ProfileComponent } from './core/components/Profile/profile/profile.component';
import { AdminTablesComponent } from './core/components/Admin/admin-tables/tables.component';
import { ShoppingCartComponent } from './core/components/Shopping Cart/shopping-cart/shopping-cart.component';
import { OrdersComponent } from './core/components/Orders/orders/orders.component';
import { CreateShopComponent } from './core/components/Shop/create-shop/create-shop.component';
import { UpdateShopComponent } from './core/components/Shop/update-shop/update-shop.component';
import { FAQComponent } from './core/components/Agreements/faq/faq.component';
import { CookiesComponent } from './core/components/Agreements/cookies/cookies.component';
import { OperationGuideComponent } from './core/components/Agreements/operation-guide/operation-guide.component';
import { PrivacyComponent } from './core/components/Agreements/privacy/privacy.component';
import { TosComponent } from './core/components/Agreements/tos/tos.component';
import { KVKKComponent } from './core/components/Agreements/kvkk/kvkk.component';
import { LandingComponent } from './core/components/Main Menu/landing/landing.component';

const routes: Routes = [
  {
    //LAYOUT COMPONENT
    path: 'Foods',
    component: AppLayoutComponent,
    children: [
      {
        path: 'Restaurants',
        component: MenuComponent,
      },
      {
        path: 'Shop/:ShopId',
        component: ShopPageComponent,
      },
      {
        path: 'Profile/:UserId',
        component: ProfileComponent,
      },
      {
        path: 'ShoppingCart/:ShoppingCartId',
        component: ShoppingCartComponent,
      },
      {
        path: 'PreviousOrders/:OrderId',
        component: OrdersComponent,
      },
      {
        path: 'UpdateShop/:ShopId',
        component: UpdateShopComponent,
      },
      {
        path: 'admin',
        component: AdminTablesComponent,
      },
      {
        path: 'Cookies',
        component: CookiesComponent,
      },
      {
        path: 'Guide',
        component: OperationGuideComponent,
      },
      {
        path: 'Privacy',
        component: PrivacyComponent,
      },
      {
        path: 'TOS',
        component: TosComponent,
      },
      {
        path: 'FAQ',
        component: FAQComponent,
      },
      {
        path: 'KVKK',
        component: KVKKComponent,
      },
      {
        path: 'Become-Partner',
        component: CreateShopComponent,
      },
    ],
    // canActivate: [authGuard],
  },
  { path: '', component: LandingComponent },
  {
    path: 'Login',
    component: LoginComponent,
  },
  {
    path: 'SignUp',
    component: SignUpComponent,
  },
  {
    path: 'CreateShop',
    component: CreateShopComponent,
  },
  {
    path: 'Cookies',
    component: CookiesComponent,
  },
  {
    path: 'Guide',
    component: OperationGuideComponent,
  },
  {
    path: 'Privacy',
    component: PrivacyComponent,
  },
  {
    path: 'TOS',
    component: TosComponent,
  },
  {
    path: 'FAQ',
    component: FAQComponent,
  },
  {
    path: 'KVKK',
    component: KVKKComponent,
  },
  {
    path: 'Become-Partner',
    component: CreateShopComponent,
  },
  {
    path: '**',
    component: NotfoundComponent,
    // canActivateChild: [],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
