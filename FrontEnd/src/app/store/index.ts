import { ActionReducerMap, MetaReducer } from '@ngrx/store';
import { AuthStoreModel } from './models/auth.model';
import { authReducer } from './reducers/auth.reducer';
import { hydrationMetaReducer } from './reducers/hydration.reducer';

export const rootReducer = {};

export interface AppState {
  AuthStore: AuthStoreModel | undefined;
}

export const reducers: ActionReducerMap<AppState, any> = {
  AuthStore: authReducer,
};

export const metaReducers: MetaReducer[] = [hydrationMetaReducer];
