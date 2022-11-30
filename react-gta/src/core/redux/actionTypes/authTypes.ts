export enum AuthActionTypes {
  SetIsAuth,
}

export interface AuthAction {
  type: AuthActionTypes;
  isAuth: boolean;
  payload?: any;
}
