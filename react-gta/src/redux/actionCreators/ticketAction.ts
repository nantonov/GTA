import { TicketActionTypes, TicketAction } from '../actionTypes/ticketTypes';
import { ITicketGetModel } from '../../modelInterfaces/getInterfaces/ITicketGetModel';

export const setTicketStart = (): TicketAction => ({
  type: TicketActionTypes.TICKET_START,
});

export const setTicketSuccess = (cities: ITicketGetModel[]): TicketAction => ({
  type: TicketActionTypes.TICKET_SUCCESS,
  payload: cities,
});

export const setTicketFail = (error: string): TicketAction => ({
  type: TicketActionTypes.TICKET_FAIL,
  payload: error,
});
