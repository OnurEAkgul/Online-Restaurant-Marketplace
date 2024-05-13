import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppLayoutComponent } from './core/layout/app.layout.component';
import { AppComponent } from './app.component';
import { SignUpComponent } from './core/components/Authorization/sign-up/sign-up.component';
import { LoginComponent } from './core/components/Authorization/login/login.component';
import { authGuard } from './core/guards/auth.guard';
import { MenuComponent } from './core/components/Main Menu/menu/menu.component';
import { ShopOwnerRegisterComponent } from './core/components/Authorization/shop-owner-register/shop-owner-register.component';
import { NotfoundComponent } from './core/components/Not Found/notfound.component';
import { ShopPageComponent } from './core/components/Shop/shop-page/shop-page.component';
import { ProfileComponent } from './core/components/Profile/profile/profile.component';
import { AdminTablesComponent } from './core/components/Admin/admin-tables/tables.component';

const routes: Routes = [
  {
    //LAYOUT COMPONENT
    path: '',
    component: AppLayoutComponent,
    children: [
      {
        path: '',
        component: MenuComponent,
      },
      {
        path: 'Shop/:id',
        component: ShopPageComponent,
      },
      {
        path: 'Profile/:id',
        component: ProfileComponent,
      },
      {
        path: 'admin',
        component: AdminTablesComponent,
      },
    ],
    canActivate: [authGuard],
  },
  {
    path: 'Login',
    component: LoginComponent,
  },
  {
    path: 'SignUp',
    component: SignUpComponent,
  },
  {
    path: 'Become-Partner',
    component: ShopOwnerRegisterComponent,
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
