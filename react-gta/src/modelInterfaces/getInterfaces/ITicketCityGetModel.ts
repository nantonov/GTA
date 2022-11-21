import { ICityGetModel } from "./ICityGetModel";
import { ITicketGetModel } from "./ITicketGetModel";

export default interface ITicketCityGetModel {
    stayingStatus: number,

    airlineTicketId: number,
    ticket: ITicketGetModel,
    cityId: number,
    city: ICityGetModel
}