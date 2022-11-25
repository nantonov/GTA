import { combineReducers } from '@reduxjs/toolkit';
import UserService from '../services/UserService';
import { AuthAction, AuthActionTypes } from './authActions';
import { ModalAction, ModalActionTypes } from './modalActions';

const initialModalState = {
  updateModal: false,
  createModal: false,
  deleteModal: false
};

const initialAuthState = {
  isAuth: false
};

function ModalReducer(state = initialModalState, action: ModalAction) {
  switch (action.type) {
    case ModalActionTypes.ShowUpdateModal:
      return {
        ...state,
        updateModal: true,
      };
    case ModalActionTypes.HideUpdateModal:
      return {
        ...state,
        updateModal: false,
      };
    case ModalActionTypes.ShowCreateModal:
    return {
      ...state,
      createModal: true,
    };
    case ModalActionTypes.HideCreateModal:
    return {
      ...state,
      createModal: false,
    };
    case ModalActionTypes.ShowDeleteModal:
    return {
      ...state,
      deleteModal: true,
    };
    case ModalActionTypes.HideDeleteModal:
    return {
      ...state,
      deleteModal: false,
    };
    default:
      return state;
  }
}

function AuthReducer(state = initialAuthState, action: AuthAction) {
  switch (action.type) {
    case AuthActionTypes.SetIsAuth:
    return {
      ...state,
      isAuth: action.isAuth
    };
    default:
      return state;
  }
}

const rootReducer = combineReducers({ modal: ModalReducer, auth: AuthReducer });
export type RootState = ReturnType<typeof rootReducer>;
export default rootReducer;