import { Injectable } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from '../store';
import { take } from 'rxjs/operators';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { UserRoleEnum } from '../models/user/UserRole';
import { UrlConstants } from '../constants';
import * as authActions from 'src/app/store/actions/auth.actions';

@Injectable({
  providedIn: 'root',
})
export class AuthGuardService implements CanActivate {
  constructor(private store: Store<AppState>, private router: Router) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Promise<boolean> {
    const role = route.data.role as UserRoleEnum;
    let allowed: boolean = false;

    return new Promise((resolve) => {
      this.store
        .select('AuthStore')
        .pipe(take(1))
        .subscribe((store) => {
          if (store !== null && store !== undefined) {
            if (
              store.userId !== null &&
              store.userId !== null &&
              store.token !== null &&
              store.token !== undefined &&
              (role === UserRoleEnum.Admin) === store.admin
            ) {
              allowed = true;
            }
          }

          if (allowed) resolve(true);
          else {
            this.router.navigate([UrlConstants.login]);

            this.store.dispatch(new authActions.Logout());
            resolve(false);
          }
        });
    });
  }
}
