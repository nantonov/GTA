import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { CreateUpdateCityModel } from '../../interfaces/modelnterfaces/createUpdateInterfaces/createUpdateCityModel';
import {
  createCityService,
  deleteCityService,
  getAllCitiesService,
  updateCityService,
} from '../../services/CityService';
import { setCityStart, setCitySuccess, setCityFail } from '../actionCreators/cityAction';
import rootReducer from '../reducers/rootReducer';

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
  (city: CreateUpdateCityModel) =>
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
  (id: number, city: CreateUpdateCityModel) =>
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
