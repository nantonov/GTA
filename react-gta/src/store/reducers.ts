import { combineReducers } from '@reduxjs/toolkit';
import { ModalAction, ModalActionTypes } from './actions';

const initialModalState = {
  updateModal: false,
  createModal: false
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
    default:
      return state;
  }
}

const rootReducer = combineReducers({ modal: ModalReducer });
export type RootState = ReturnType<typeof rootReducer>;
export default rootReducer;