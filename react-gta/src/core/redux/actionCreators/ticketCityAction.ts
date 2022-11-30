import { TicketCityActionTypes, TicketCityAction } from '../actionTypes/ticketCityTypes';
import TicketCityGetModel from '../../interfaces/modelnterfaces/getInterfaces/ticketCityGetModel';

export const setTicketCityStart = (): TicketCityAction => ({
  type: TicketCityActionTypes.TICKETCITY_START,
});

export const setTicketCitySuccess = (ticketCities: TicketCityGetModel[]): TicketCityAction => ({
  type: TicketCityActionTypes.TICKETCITY_SUCCESS,
  payload: ticketCities,
});

export const setTicketCityFail = (error: string): TicketCityAction => ({
  type: TicketCityActionTypes.TICKETCITY_FAIL,
  payload: error,
});
