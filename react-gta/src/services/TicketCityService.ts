import axios from "axios"
import { axiosConfig } from "../configuration/axiosConfig"; 
import { ICreateUpdateTicketCityModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateTicketCityModel";
import ITicketCityGetModel from "../modelInterfaces/getInterfaces/ITicketCityGetModel";

export default class TicketCityService {
    static async delete(ticketId: number, cityId: number) {
        const response = await axios.delete(`${axiosConfig.ticketCityUrl}/ticket/${ticketId}/city/${cityId}`)
        return response.data
    }

    static async create(ticketCity: ICreateUpdateTicketCityModel) {
        const response = await axios.post(`${axiosConfig.ticketCityUrl}`, ticketCity, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
    
    static async getAll(): Promise<Array<ITicketCityGetModel>> {
        const response = await axios.get(`${axiosConfig.ticketCityUrl}`)
        return response.data
    }

    static async update(ticketCity: ICreateUpdateTicketCityModel) {
        const response = await axios.put(`${axiosConfig.ticketCityUrl}`, ticketCity, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
}