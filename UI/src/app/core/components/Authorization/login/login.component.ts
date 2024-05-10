import { Component, OnDestroy } from '@angular/core';
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

  constructor(private userService: UserActionsService) {
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
    this.LoginSubs = this.userService
      .Login(this.loginModel)
      .subscribe((response) => {
        console.log(response);
      });
  }
}
