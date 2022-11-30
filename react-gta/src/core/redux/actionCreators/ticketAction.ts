import { TicketActionTypes, TicketAction } from '../actionTypes/ticketTypes';
import { TicketGetModel } from '../../interfaces/modelnterfaces/getInterfaces/ticketGetModel';

export const setTicketStart = (): TicketAction => ({
  type: TicketActionTypes.TICKET_START,
});

export const setTicketSuccess = (cities: TicketGetModel[]): TicketAction => ({
  type: TicketActionTypes.TICKET_SUCCESS,
  payload: cities,
});

export const setTicketFail = (error: string): TicketAction => ({
  type: TicketActionTypes.TICKET_FAIL,
  payload: error,
});
