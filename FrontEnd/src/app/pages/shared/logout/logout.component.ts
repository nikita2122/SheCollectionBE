import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Store } from '@ngrx/store';
import { UrlConstants } from 'src/app/constants';
import { AppState } from 'src/app/store';
import * as authActions from 'src/app/store/actions/auth.actions';

@Component({
  selector: 'app-logout',
  template: '',
})
export class LogoutComponent {
  constructor(private store: Store<AppState>, private router: Router) {
    this.store.dispatch(new authActions.Logout());
    this.router.navigate([UrlConstants.login]);
  }
}
