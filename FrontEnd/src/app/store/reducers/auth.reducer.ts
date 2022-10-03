import * as AuthActions from '../actions/auth.actions';
import { AuthStoreModel } from '../models/auth.model';

export type Action = AuthActions.All;

const defaultState: AuthStoreModel | undefined = undefined;

const newState = (state: any, newData: any) => {
  return Object.assign({}, state, newData);
};

export function authReducer(
  state: AuthStoreModel | undefined = defaultState,
  action: Action
) {
  switch (action.type) {
    case AuthActions.LOGIN:
      return newState(state, action.payload);

    case AuthActions.LOGOUT:
      return defaultState;

    default:
      return state;
  }
}
