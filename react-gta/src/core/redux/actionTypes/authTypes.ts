export enum AuthActionTypes {
  SetIsAuth,
}

export interface AuthAction {
  type: AuthActionTypes;
  payload?: any;
}
