import axios from "axios"
import { axiosConfig } from "../configuration/axiosConfig"; 
import { ICreateUpdateHotelModel } from "../models/ICreateUpdateHotelModel";

export default class HotelService {
    static async delete(id: number) {
        const response = await axios.delete(`${axiosConfig.ticketsAPIUrl}/hotel/${id}`)
        return response.data
    }

    static async create(hotel: ICreateUpdateHotelModel) {
        const response = await axios.post(`${axiosConfig.ticketsAPIUrl}/hotel`, hotel, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
    
    static async getAll() {
        const response = await axios.get(`${axiosConfig.ticketsAPIUrl}/hotel`)
        return response.data
    }

    static async update(id: number, hotel: ICreateUpdateHotelModel) {
        const response = await axios.put(`${axiosConfig.ticketsAPIUrl}/hotel/${id}`, hotel, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
}