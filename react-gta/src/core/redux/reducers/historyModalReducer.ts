import { HistoryModalAction, HistoryModalActionTypes } from '../actionTypes/historyModalTypes';

const initialHistoryModalState = {
  idModal: false,
  createModal: false,
};

function HistoryModalReducer(state = initialHistoryModalState, action: HistoryModalAction) {
  switch (action.type) {
    case HistoryModalActionTypes.ShowIdModal:
      return {
        ...state,
        idModal: true,
      };
    case HistoryModalActionTypes.HideIdModal:
      return {
        ...state,
        idModal: false,
      };
    case HistoryModalActionTypes.ShowCreateModal:
      return {
        ...state,
        createModal: true,
      };
    case HistoryModalActionTypes.HideCreateModal:
      return {
        ...state,
        createModal: false,
      };
    default:
      return state;
  }
}

export default HistoryModalReducer;
