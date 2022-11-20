import axios from "axios"
import { axiosConfig } from "../configuration/axiosConfig"; 
import { ICreateUpdateTicketModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateTicketModel";
import { ITicketGetModel } from "../modelInterfaces/getInterfaces/ITicketGetModel";

export default class TicketService {

    static async delete(id: number) {
        const response = await axios.delete(`${axiosConfig.ticketUrl}/${id}`)
        return response.data
    }

    static async create(ticket: ICreateUpdateTicketModel) {
        const response = await axios.post(`${axiosConfig.ticketUrl}`, ticket, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
    
    static async getAll(): Promise<Array<ITicketGetModel>> {
        const response = await axios.get(`${axiosConfig.ticketUrl}`)
        return response.data
    }

    static async update(id: number, ticket: ICreateUpdateTicketModel) {
        const response = await axios.put(`${axiosConfig.ticketUrl}/${id}`, ticket, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
}