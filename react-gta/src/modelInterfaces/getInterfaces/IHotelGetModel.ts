import { ICityGetModel } from "./ICityGetModel";

export default interface IHotelGetModel {
    id: number,
    name: string,
    starsNumber: number,
    roomsNumber: number,
    
    city: ICityGetModel
}