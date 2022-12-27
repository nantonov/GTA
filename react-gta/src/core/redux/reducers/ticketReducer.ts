import { TicketGetModel } from '../../interfaces/modelnterfaces/getInterfaces/ticketGetModel';
import { TicketAction, TicketActionTypes } from '../actionTypes/ticketTypes';

export interface InitTicketState {
  tickets: TicketGetModel[];
  ticket: TicketGetModel | null;
  isLoading: boolean;
  error: string | null;
}

const initialState: InitTicketState = {
  tickets: [],
  ticket: null,
  isLoading: false,
  error: null,
};

const ticketReducer = (state = initialState, action: TicketAction): InitTicketState => {
  switch (action.type) {
    case TicketActionTypes.TICKET_START:
      return {
        ...state,
        isLoading: true,
      };
    case TicketActionTypes.TICKET_SUCCESS:
      return {
        ...state,
        isLoading: false,
        tickets: action.payload,
      };
    case TicketActionTypes.TICKET_SUCCESS_SEPARATE:
      return {
        ...state,
        isLoading: false,
        ticket: action.payload,
      };
    case TicketActionTypes.TICKET_FAIL:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default ticketReducer;
