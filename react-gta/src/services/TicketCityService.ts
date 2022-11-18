import axios from "axios"
import { axiosConfig } from "../configuration/axiosConfig"; 
import { ICreateUpdateTicketCityModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateTicketCityModel";

export default class TicketCityService {
    static async delete(ticketId: number, cityId: number) {
        const response = await axios.delete(`${axiosConfig.ticketsAPIUrl}/airlineticketcity/ticket/${ticketId}/city/${cityId}`)
        return response.data
    }

    static async create(ticketCity: ICreateUpdateTicketCityModel) {
        const response = await axios.post(`${axiosConfig.ticketsAPIUrl}/airlineticketcity`, ticketCity, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
    
    static async getAll() {
        const response = await axios.get(`${axiosConfig.ticketsAPIUrl}/airlineticketcity`)
        return response.data
    }

    static async update(ticketCity: ICreateUpdateTicketCityModel) {
        const response = await axios.put(`${axiosConfig.ticketsAPIUrl}/airlineticketcity`, ticketCity, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
}