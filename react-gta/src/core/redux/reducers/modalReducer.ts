import { ModalAction, ModalActionTypes } from '../actionTypes/modalTypes';

const initialModalState = {
  updateModal: false,
  createModal: false,
  deleteModal: false,
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

export default ModalReducer;
