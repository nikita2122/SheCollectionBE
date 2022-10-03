import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UrlConstants } from 'src/app/constants';
import { updatePasswordModel } from 'src/app/models/auth/UpdatePasswordModel';
import { AuthService } from 'src/app/services/auth.service';
import { take } from 'rxjs/operators';

@Component({
  selector: 'app-update-psswd',
  templateUrl: './update-psswd.component.html',
  styleUrls: ['./update-psswd.component.scss'],
})
export class UpdatePsswdComponent implements OnInit {
  loading: boolean = false;
  email!: string;
  oldPassword!: string;
  newPassword!: string;
  newPasswordConf!: string;

  constructor(private router: Router, private authService: AuthService) {}

  ngOnInit(): void {}

  update() {
    const model: updatePasswordModel = {
      email: this.email,
      oldPassword: this.oldPassword,
      newPassword: this.newPassword,
    };

    this.authService
      .updatePassword(model)
      .pipe(take(1))
      .subscribe({
        next: (res) => {
          this.router.navigate([UrlConstants.account]);
        },
      });
  }

  cancel() {
    this.router.navigate([UrlConstants.account]);
  }
}
