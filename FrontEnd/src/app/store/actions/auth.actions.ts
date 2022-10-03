import { Action } from '@ngrx/store';
import { AuthStoreModel } from '../models/auth.model';

export const LOGIN = '[AUTH] LOGIN';
export const LOGOUT = '[AUTH] LOGOUT';

export class Login implements Action {
  readonly type: string = LOGIN;

  constructor(public payload: AuthStoreModel) {}
}

export class Logout implements Action {
  readonly type = LOGOUT;
  constructor() {}
}

export type All = Login | Logout;
