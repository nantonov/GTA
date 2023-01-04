import { TicketGetModel } from '../../interfaces/modelnterfaces/getInterfaces/ticketGetModel';

export enum TicketActionTypes {
  TICKET_START = 'TICKET_START',
  TICKET_SUCCESS = 'TICKET_SUCCESS',
  TICKET_SUCCESS_SEPARATE = 'TICKET_SUCCESS_SEPARATE',
  TICKET_FAIL = 'TICKET_FAIL',
}

interface TicketStartAction {
  type: TicketActionTypes.TICKET_START;
}

interface TicketSuccessAction {
  type: TicketActionTypes.TICKET_SUCCESS;
  payload: TicketGetModel[];
}

interface TicketSuccessSeparateAction {
  type: TicketActionTypes.TICKET_SUCCESS_SEPARATE;
  payload: TicketGetModel;
}

interface TicketFailAction {
  type: TicketActionTypes.TICKET_FAIL;
  payload: string;
}

export type TicketAction =
  | TicketStartAction
  | TicketSuccessAction
  | TicketSuccessSeparateAction
  | TicketFailAction;
