import axios from "axios"
import { axiosConfig } from "../configuration/axiosConfig"; 
import { ICreateUpdateTicketModel } from "../models/ICreateUpdateTicketModel";

export default class TicketService {

    static async delete(id: number) {
        const response = await axios.delete(`${axiosConfig.ticketsAPIUrl}/airlineticket/${id}`)
        return response.data
    }

    static async create(ticket: ICreateUpdateTicketModel) {
        const response = await axios.post(`${axiosConfig.ticketsAPIUrl}/airlineticket`, ticket, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
    
    static async getAll() {
        const response = await axios.get(`${axiosConfig.ticketsAPIUrl}/airlineticket`)
        return response.data
    }

    static async update(id: number, ticket: ICreateUpdateTicketModel) {
        const response = await axios.put(`${axiosConfig.ticketsAPIUrl}/airlineticket/${id}`, ticket, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
}