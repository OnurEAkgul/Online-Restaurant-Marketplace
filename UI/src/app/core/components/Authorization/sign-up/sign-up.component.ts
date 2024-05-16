import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';
import { SignUpModel } from 'src/app/core/services/UserActions/models/SignUp.model';
import { UserActionsService } from 'src/app/core/services/UserActions/user-actions.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css'],
})
export class SignUpComponent {
  signupmodel: SignUpModel;

  constructor(
    private userService: UserActionsService,
    private message: MessageService
  ) {
    this.signupmodel = {
      email: '',
      password: '',
      username: '',
      phoneNumber: '',
    };
  }

  SignUp() {
    // console.log(this.signupmodel);
    this.userService.SignUp(this.signupmodel).subscribe((response) => {
      // console.log(response);
    });
  }
}
