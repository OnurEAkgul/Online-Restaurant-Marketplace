import { Component, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnDestroy {
  // Checkbox: boolean = false;

  LoginSubs?: Subscription;
  loginModel: any;

  constructor(private userService: UserActionsService, private router: Router) {
    this.loginModel = {
      email: '',
      password: '',
      rememberMe: false,
      username: '',
    };
  }
  ngOnDestroy(): void {
    this.LoginSubs?.unsubscribe();
  }
  Login() {
    this.loginModel.username = this.loginModel.email;
    this.LoginSubs = this.userService.Login(this.loginModel).subscribe(
      (response) => {
        console.log(response);
        console.log(response.token);
        this.userService.SaveToCookies(response.token);
        this.router.navigateByUrl('');
      },
      (error) => {
        console.log(error.message);
      }
    );
  }
}
