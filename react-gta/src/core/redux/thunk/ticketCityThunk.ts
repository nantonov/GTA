import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { CreateUpdateTicketCityModel } from '../../interfaces/modelnterfaces/createUpdateInterfaces/createUpdateTicketCityModel';
import {
  createTicketCityService,
  deleteTicketCityService,
  getAllTicketCitiesService,
  updateTicketCityService,
} from '../../services/TicketCityService';
import rootReducer from '../reducers/rootReducer';
import {
  setTicketCityFail,
  setTicketCityStart,
  setTicketCitySuccess,
} from '../actionCreators/ticketCityAction';

export const getAllTicketCities =
  () => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setTicketCityStart());
      const ticketCities = await getAllTicketCitiesService();
      dispatch(setTicketCitySuccess(ticketCities));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setTicketCityFail(errorMessage));
    }
  };

export const postTicketCity =
  (ticketCity: CreateUpdateTicketCityModel) =>
  async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setTicketCityStart());
      const result = await createTicketCityService(ticketCity);
      if (result) {
        const ticketCities = await getAllTicketCitiesService();
        dispatch(setTicketCitySuccess(ticketCities));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setTicketCityFail(errorMessage));
    }
  };

export const deleteTicketCity =
  (ticketId: number, cityId: number) =>
  async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setTicketCityStart());
      const result = await deleteTicketCityService(ticketId, cityId);
      if (result) {
        const ticketCities = await getAllTicketCitiesService();
        dispatch(setTicketCitySuccess(ticketCities));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setTicketCityFail(errorMessage));
    }
  };

export const updateTicketCity =
  (ticketCity: CreateUpdateTicketCityModel) =>
  async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setTicketCityStart());
      const result = await updateTicketCityService(ticketCity);
      if (result) {
        const ticketCities = await getAllTicketCitiesService();
        dispatch(setTicketCitySuccess(ticketCities));
      }
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setTicketCityFail(errorMessage));
    }
  };
