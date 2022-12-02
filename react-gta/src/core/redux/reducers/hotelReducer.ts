import HotelGetModel from '../../interfaces/modelnterfaces/getInterfaces/hotelGetModel';
import { HotelAction, HotelActionTypes } from '../actionTypes/hotelTypes';

export interface InitHotelState {
  hotels: HotelGetModel[];
  isLoading: boolean;
  error: string | null;
}

const initialState: InitHotelState = {
  hotels: [],
  isLoading: false,
  error: null,
};

const hotelReducer = (state = initialState, action: HotelAction): InitHotelState => {
  switch (action.type) {
    case HotelActionTypes.HOTEL_START:
      return {
        ...state,
        isLoading: true,
      };
    case HotelActionTypes.HOTEL_SUCCESS:
      return {
        ...state,
        isLoading: false,
        hotels: action.payload,
      };
    case HotelActionTypes.HOTEL_FAIL:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default hotelReducer;
