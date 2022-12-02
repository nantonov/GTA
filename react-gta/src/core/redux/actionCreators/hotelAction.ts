import { HotelActionTypes, HotelAction } from '../actionTypes/hotelTypes';
import HotelGetModel from '../../interfaces/modelnterfaces/getInterfaces/hotelGetModel';

export const setHotelStart = (): HotelAction => ({
  type: HotelActionTypes.HOTEL_START,
});

export const setHotelSuccess = (hotels: HotelGetModel[]): HotelAction => ({
  type: HotelActionTypes.HOTEL_SUCCESS,
  payload: hotels,
});

export const setHotelFail = (error: string): HotelAction => ({
  type: HotelActionTypes.HOTEL_FAIL,
  payload: error,
});
