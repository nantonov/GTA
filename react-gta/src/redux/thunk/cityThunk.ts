import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { ICreateUpdateCityModel } from '../../modelInterfaces/createUpdateInterfaces/ICreateUpdateCityModel';
import {
  createCityService,
  deleteCityService,
  getAllCitiesService,
  updateCityService,
} from '../../services/CityService';
import rootReducer from '../../store/reducers';
import { setCityFail, setCityStart, setCitySuccess } from '../actionCreators/cityAction';

export const getAllCities =
  () => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setCityStart());
      const cities = await getAllCitiesService();
      dispatch(setCitySuccess(cities));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setCityFail(errorMessage));
    }
  };

export const postCity =
  (city: ICreateUpdateCityModel) =>
  async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setCityStart());
      const result = await createCityService(city);
      if (result) {
        const cities = await getAllCitiesService();
        dispatch(setCitySuccess(cities));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setCityFail(errorMessage));
    }
  };

export const deleteCity =
  (id: number) => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setCityStart());
      const result = await deleteCityService(id);
      if (result) {
        const cities = await getAllCitiesService();
        dispatch(setCitySuccess(cities));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setCityFail(errorMessage));
    }
  };

export const updateCity =
  (id: number, city: ICreateUpdateCityModel) =>
  async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setCityStart());
      const result = await updateCityService(id, city);
      if (result) {
        const cities = await getAllCitiesService();
        dispatch(setCitySuccess(cities));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setCityFail(errorMessage));
    }
  };
