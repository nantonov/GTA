import { ICreateUpdateCityModel } from "./ICreateUpdateCityModel";

export interface ICreateUpdateHotelModel {
    name: string,
    starsNumber: number,
    roomsNumber: number,
    
    cityId: number
}