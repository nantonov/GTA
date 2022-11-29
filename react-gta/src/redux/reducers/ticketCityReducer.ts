import ITicketCityGetModel from '../../modelInterfaces/getInterfaces/ITicketCityGetModel';
import { TicketCityAction, TicketCityActionTypes } from '../actionTypes/ticketCityTypes';

export interface InitTicketCityState {
  ticketCities: ITicketCityGetModel[];
  isLoading: boolean;
  error: string | null;
}

const initialState: InitTicketCityState = {
  ticketCities: [],
  isLoading: false,
  error: null,
};

const ticketCityReducer = (state = initialState, action: TicketCityAction): InitTicketCityState => {
  switch (action.type) {
    case TicketCityActionTypes.TICKETCITY_START:
      return {
        ...state,
        isLoading: true,
      };
    case TicketCityActionTypes.TICKETCITY_SUCCESS:
      return {
        ...state,
        isLoading: false,
        ticketCities: action.payload,
      };
    case TicketCityActionTypes.TICKETCITY_FAIL:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default ticketCityReducer;
