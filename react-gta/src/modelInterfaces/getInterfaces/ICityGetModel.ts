import IHotelGetModel from "./IHotelGetModel";
import ITicketCityGetModel from "./ITicketCityGetModel";

export interface ICityGetModel {
    id: number,
    name: string,
    population: number,
    area: number,

    ticketCities: Array<ITicketCityGetModel>,
    hotels: Array<IHotelGetModel>
}