import TicketCityGetModel from '../../interfaces/modelnterfaces/getInterfaces/ticketCityGetModel';

export enum TicketCityActionTypes {
  TICKETCITY_START = 'TICKETCITY_START',
  TICKETCITY_SUCCESS = 'TICKETCITY_SUCCESS',
  TICKETCITY_FAIL = 'TICKETCITY_FAIL',
}

interface TicketCityStartAction {
  type: TicketCityActionTypes.TICKETCITY_START;
}

interface TicketCitySuccessAction {
  type: TicketCityActionTypes.TICKETCITY_SUCCESS;
  payload: TicketCityGetModel[];
}

interface TicketCityFailAction {
  type: TicketCityActionTypes.TICKETCITY_FAIL;
  payload: string;
}

export type TicketCityAction =
  | TicketCityStartAction
  | TicketCitySuccessAction
  | TicketCityFailAction;
