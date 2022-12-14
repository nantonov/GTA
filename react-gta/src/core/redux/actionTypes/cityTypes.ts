import { CityGetModel } from '../../interfaces/modelnterfaces/getInterfaces/cityGetModel';

export enum CityActionTypes {
  CITY_START = 'CITY_START',
  CITY_SUCCESS = 'CITY_SUCCESS',
  CITY_FAIL = 'CITY_FAIL',
}

interface CityStartAction {
  type: CityActionTypes.CITY_START;
}

interface CitySuccessAction {
  type: CityActionTypes.CITY_SUCCESS;
  payload: CityGetModel[];
}

interface CityFailAction {
  type: CityActionTypes.CITY_FAIL;
  payload: string;
}

export type CityAction = CityStartAction | CitySuccessAction | CityFailAction;
