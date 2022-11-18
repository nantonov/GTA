import ITicketCityGetModel from "./ITicketCityGetModel";

export interface ITicketGetModel {
    id: number,
    departureTime: Date,
    arrivalTime: Date,
    price: number,
    passengerCredentials: string,

    ticketCities: Array<ITicketCityGetModel>
}