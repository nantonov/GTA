import { CityStayingStatus } from "../enums/CityStayingStatus";

export interface ICreateUpdateTicketCityModel {
    status: CityStayingStatus,
    
    airlineTicketId: number,
    cityId: number
}