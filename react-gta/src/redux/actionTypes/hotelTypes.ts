import IHotelGetModel from '../../modelInterfaces/getInterfaces/IHotelGetModel';

export enum HotelActionTypes {
  HOTEL_START = 'HOTEL_START',
  HOTEL_SUCCESS = 'HOTEL_SUCCESS',
  HOTEL_FAIL = 'HOTEL_FAIL',
}

interface HotelStartAction {
  type: HotelActionTypes.HOTEL_START;
}

interface HotelSuccessAction {
  type: HotelActionTypes.HOTEL_SUCCESS;
  payload: IHotelGetModel[];
}

interface HotelFailAction {
  type: HotelActionTypes.HOTEL_FAIL;
  payload: string;
}

export type HotelAction = HotelStartAction | HotelSuccessAction | HotelFailAction;
