import { CityActionTypes, CityAction } from '../actionTypes/cityTypes';
import { CityGetModel } from '../../interfaces/modelnterfaces/getInterfaces/cityGetModel';

export const setCityStart = (): CityAction => ({
  type: CityActionTypes.CITY_START,
});

export const setCitySuccess = (cities: CityGetModel[]): CityAction => ({
  type: CityActionTypes.CITY_SUCCESS,
  payload: cities,
});

export const setCityFail = (error: string): CityAction => ({
  type: CityActionTypes.CITY_FAIL,
  payload: error,
});
