import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppLayoutComponent } from './core/layout/app.layout.component';
import { AppComponent } from './app.component';
import { SignUpComponent } from './core/components/Authorization/sign-up/sign-up.component';
import { LoginComponent } from './core/components/Authorization/login/login.component';

const routes: Routes = [
  {
    //LAYOUT COMPONENT
    path: '',
    component: AppLayoutComponent,
    children: [
      {
        path: '',
        component: LoginComponent,
      },
      {
        path: 'SignUp',
        component: SignUpComponent,
      },
    ],
    // canActivate: [authGuard],
  },
  {
    path: 'Loginsss',
    component: LoginComponent,
  },
  {
    path: 'SignUpsss',
    component: SignUpComponent,
  },
  // {
  //   path: '**',
  //   // component: LandingComponent,
  //   // canActivateChild: [],
  // },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
