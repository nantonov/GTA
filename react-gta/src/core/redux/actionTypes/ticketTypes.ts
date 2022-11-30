import { TicketGetModel } from '../../interfaces/modelnterfaces/getInterfaces/ticketGetModel';

export enum TicketActionTypes {
  TICKET_START = 'TICKET_START',
  TICKET_SUCCESS = 'TICKET_SUCCESS',
  TICKET_FAIL = 'TICKET_FAIL',
}

interface TicketStartAction {
  type: TicketActionTypes.TICKET_START;
}

interface TicketSuccessAction {
  type: TicketActionTypes.TICKET_SUCCESS;
  payload: TicketGetModel[];
}

interface TicketFailAction {
  type: TicketActionTypes.TICKET_FAIL;
  payload: string;
}

export type TicketAction = TicketStartAction | TicketSuccessAction | TicketFailAction;
