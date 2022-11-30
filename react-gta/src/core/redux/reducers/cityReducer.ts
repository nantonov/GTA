import { CityGetModel } from '../../interfaces/modelnterfaces/getInterfaces/cityGetModel';
import { CityAction, CityActionTypes } from '../actionTypes/cityTypes';

export interface InitCityState {
  cities: CityGetModel[];
  isLoading: boolean;
  error: string | null;
}

const initialState: InitCityState = {
  cities: [],
  isLoading: false,
  error: null,
};

const cityReducer = (state = initialState, action: CityAction): InitCityState => {
  switch (action.type) {
    case CityActionTypes.CITY_START:
      return {
        ...state,
        isLoading: true,
      };
    case CityActionTypes.CITY_SUCCESS:
      return {
        ...state,
        isLoading: false,
        cities: action.payload,
      };
    case CityActionTypes.CITY_FAIL:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default cityReducer;
