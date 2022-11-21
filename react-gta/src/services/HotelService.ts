import axios from "axios"
import { axiosConfig } from "../configuration/axiosConfig"; 
import { ICreateUpdateHotelModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateHotelModel";
import IHotelGetModel from "../modelInterfaces/getInterfaces/IHotelGetModel";

export default class HotelService {
    static async delete(id: number) {
        const response = await axios.delete(`${axiosConfig.hotelUrl}/${id}`)
        return response.data
    }

    static async create(hotel: ICreateUpdateHotelModel) {
        const response = await axios.post(`${axiosConfig.hotelUrl}`, hotel, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
    
    static async getAll(): Promise<Array<IHotelGetModel>> {
        const response = await axios.get(`${axiosConfig.hotelUrl}`)
        return response.data
    }

    static async update(id: number, hotel: ICreateUpdateHotelModel) {
        const response = await axios.put(`${axiosConfig.hotelUrl}/${id}`, hotel, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
}