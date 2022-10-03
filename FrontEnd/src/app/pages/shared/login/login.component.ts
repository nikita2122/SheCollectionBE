import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, Subscription } from 'rxjs';
import { take } from 'rxjs/operators';
import { UrlConstants } from 'src/app/constants';
import { LoginModel } from 'src/app/models/auth/LoginModel';
import { UserRoleEnum } from 'src/app/models/user/UserRole';
import { AuthService } from 'src/app/services/auth.service';
import { AppState } from 'src/app/store';
import * as authActions from 'src/app/store/actions/auth.actions';
import { AuthStoreModel } from 'src/app/store/models/auth.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit, OnDestroy {
  loginForm: FormGroup;
  auth!: AuthStoreModel | undefined;
  private authSub!: Subscription;
  constructor(
    private store: Store<AppState>,
    private fb: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.authSub = this.store.select('AuthStore').subscribe((res) => {
      this.auth = res;
      if (this.auth !== undefined) this.router.navigate([UrlConstants.home]);
    });
  }

  submit() {
    const user: LoginModel = {
      UserName: this.loginForm.get('username')?.value,
      Password: this.loginForm.get('password')?.value,
    };

    this.authService
      .login(user)
      .pipe(take(1))
      .subscribe((res) => {
        const authStore: AuthStoreModel = {
          token: res.token,
          admin: res.role.userRoleId === UserRoleEnum.Admin,
          userId: res.userId,
        };

        this.store.dispatch(new authActions.Login(authStore));
      });
  }

  ngOnDestroy(): void {
    this.authSub.unsubscribe();
  }
}
