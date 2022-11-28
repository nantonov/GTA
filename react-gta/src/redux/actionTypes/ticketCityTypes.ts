import ITicketCityGetModel from "../../modelInterfaces/getInterfaces/ITicketCityGetModel";

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
    payload: ITicketCityGetModel[]
}

interface TicketCityFailAction {
    type: TicketCityActionTypes.TICKETCITY_FAIL;
    payload: string
}

export type TicketCityAction = 
    | TicketCityStartAction
    | TicketCitySuccessAction
    | TicketCityFailAction