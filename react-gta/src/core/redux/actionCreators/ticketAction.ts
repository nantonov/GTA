import { TicketActionTypes, TicketAction } from '../actionTypes/ticketTypes';
import { TicketGetModel } from '../../interfaces/modelnterfaces/getInterfaces/ticketGetModel';

export const setTicketStart = (): TicketAction => ({
  type: TicketActionTypes.TICKET_START,
});

export const setTicketSuccess = (tickets: TicketGetModel[]): TicketAction => ({
  type: TicketActionTypes.TICKET_SUCCESS,
  payload: tickets,
});

export const setTicketSuccessSeparate = (ticket: TicketGetModel): TicketAction => ({
  type: TicketActionTypes.TICKET_SUCCESS_SEPARATE,
  payload: ticket,
});

export const setTicketFail = (error: string): TicketAction => ({
  type: TicketActionTypes.TICKET_FAIL,
  payload: error,
});
