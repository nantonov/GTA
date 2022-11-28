import { TicketCityActionTypes, TicketCityAction } from "../actionTypes/ticketCityTypes";
import ITicketCityGetModel from "../../modelInterfaces/getInterfaces/ITicketCityGetModel";

export const setTicketCityStart = (): TicketCityAction => ({
    type: TicketCityActionTypes.TICKETCITY_START
})

export const setTicketCitySuccess = (ticketCities: ITicketCityGetModel[]): TicketCityAction => ({
    type: TicketCityActionTypes.TICKETCITY_SUCCESS,
    payload: ticketCities
})

export const setTicketCityFail = (error: string): TicketCityAction => ({
    type: TicketCityActionTypes.TICKETCITY_FAIL,
    payload: error
})