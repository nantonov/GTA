import { AuthAction, AuthActionTypes } from '../actionTypes/authTypes';

export interface InitAuthState {
  isAuth: boolean;
}

const initialAuthState = {
  isAuth: false,
};

function AuthReducer(state = initialAuthState, action: AuthAction): InitAuthState {
  switch (action.type) {
    case AuthActionTypes.SetIsAuth:
      return {
        ...state,
        isAuth: action.payload,
      };
    default:
      return state;
  }
}

export default AuthReducer;
