import { UserTicketsHistoryGetModel } from '../../interfaces/modelnterfaces/getInterfaces/userTicketsHistoryGetModel';
import { HistoryAction, HistoryActionTypes } from '../actionTypes/historyTypes';

export interface InitHistoryState {
  history: UserTicketsHistoryGetModel | null;
  histories: UserTicketsHistoryGetModel[];
  isLoading: boolean;
  error: string | null;
}

const initialState: InitHistoryState = {
  history: null,
  histories: [],
  isLoading: false,
  error: null,
};

const historyReducer = (state = initialState, action: HistoryAction): InitHistoryState => {
  switch (action.type) {
    case HistoryActionTypes.HISTORY_START:
      return {
        ...state,
        isLoading: true,
      };
    case HistoryActionTypes.HISTORY_SUCCESS:
      return {
        ...state,
        isLoading: false,
      };
    case HistoryActionTypes.HISTORY_FAIL:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default historyReducer;
