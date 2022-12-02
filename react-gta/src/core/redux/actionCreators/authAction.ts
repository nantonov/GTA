import { AuthAction } from '../actionTypes/authTypes';
import { AuthActionTypes } from '../actionTypes/authTypes';

export function setIsAuth(isAuth: boolean): AuthAction {
  return {
    type: AuthActionTypes.SetIsAuth,
    isAuth: isAuth,
  };
}
