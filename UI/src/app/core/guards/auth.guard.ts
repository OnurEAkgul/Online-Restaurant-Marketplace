import { CanActivateFn, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { UserActionsService } from '../services/UserActions/user-actions.service';
import { inject } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
export const authGuard: CanActivateFn = (route, state) => {
  const cookieService = inject(CookieService);
  const UserService = inject(UserActionsService);
  const router = inject(Router);
  // console.log(cookieService.get('Authorization'));
  if (cookieService.get('Authorization')) {
    const user: any = UserService.TokenDecode(
      cookieService.get('Authorization')
    );
    // if (user) console.log(user);
  }

  // const expectedUserId = route.params['userId'];

  // let token = cookieService.get('Authorization');

  // // console.log(user);
  // if (token && user) {
  //   token = token.replace('Bearer', '');
  //   const decodedToken: any = jwtDecode(token);

  //   const expirationDate = decodedToken.exp * 1000;
  //   const currentTime = new Date().getTime();

  //   console.log(expirationDate);
  //   console.log(currentTime);
  //   console.log(expirationDate < currentTime);
  //   if (expirationDate < currentTime) {
  //     //token expired
  //     alert('İnaktiflikten dolayı çıkış yapılmıştır');
  //     UserService.Logout();
  //     return router.createUrlTree(['userislem/giris'], {
  //       queryParams: { returnUrl: state.url },
  //     });
  //   } else {
  //     if (user.role.includes('adminRole')) {
  //       return true;
  //     } else {
  //       //token still valid

  //       // console.log(expectedUserId);
  //       // console.log(user.userId);
  //       if (user.role.includes('userRole') && user.userId === expectedUserId) {
  //         return true;
  //       }
  //       if (user.role.includes('adminRole')) {
  //         return true;
  //       } else {
  //         alert('Unauthorized');
  //         return false;
  //       }
  //     }
  //   }
  // } else {
  //   UserActionsService.logout();
  //   alert('Unauthorized');
  //   return router.createUrlTree(['userislem/giris'], {
  //     queryParams: { returnUrl: state.url },
  //   });
  // }
  return true;
};