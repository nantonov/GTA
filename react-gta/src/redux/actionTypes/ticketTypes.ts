import { ITicketGetModel } from '../../modelInterfaces/getInterfaces/ITicketGetModel';

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
  payload: ITicketGetModel[];
}

interface TicketFailAction {
  type: TicketActionTypes.TICKET_FAIL;
  payload: string;
}

export type TicketAction = TicketStartAction | TicketSuccessAction | TicketFailAction;
