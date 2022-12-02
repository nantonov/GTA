import { AuthAction, AuthActionTypes } from '../actionTypes/authTypes';

const initialAuthState = {
  isAuth: false,
};

function AuthReducer(state = initialAuthState, action: AuthAction) {
  switch (action.type) {
    case AuthActionTypes.SetIsAuth:
      return {
        ...state,
        isAuth: action.isAuth,
      };
    default:
      return state;
  }
}

export default AuthReducer;
