import { HotelActionTypes, HotelAction } from '../actionTypes/hotelTypes';
import IHotelGetModel from '../../modelInterfaces/getInterfaces/IHotelGetModel';

export const setHotelStart = (): HotelAction => ({
  type: HotelActionTypes.HOTEL_START,
});

export const setHotelSuccess = (hotels: IHotelGetModel[]): HotelAction => ({
  type: HotelActionTypes.HOTEL_SUCCESS,
  payload: hotels,
});

export const setHotelFail = (error: string): HotelAction => ({
  type: HotelActionTypes.HOTEL_FAIL,
  payload: error,
});
