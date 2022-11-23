import axios from "axios"
import { axiosConfig } from "../configuration/axiosConfig"; 
import { ICreateUpdateTicketModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateTicketModel";
import { ITicketGetModel } from "../modelInterfaces/getInterfaces/ITicketGetModel";
import UserService from "./UserService";

const axiosInstance = axios.create({
    baseURL:axiosConfig.baseUrl
});

axiosInstance.interceptors.request.use(
    async (config: any) => {
        const token = await UserService.getUser().then((user) => {
        return user?.access_token;
        });
        if (token) config.headers.Authorization = `Bearer ${token}`;
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

export default class TicketService {

    static async delete(id: number) {
        const response = await axiosInstance.delete(`/airlineticket/${id}`)
        return response.data
    }

    static async create(ticket: ICreateUpdateTicketModel) {
        const response = await axiosInstance.post(`/airlineticket`, ticket, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
    
    static async getAll(): Promise<Array<ITicketGetModel>> {
        const response = await axiosInstance.get(`/airlineticket`)
        return response.data
    }

    static async update(id: number, ticket: ICreateUpdateTicketModel) {
        const response = await axiosInstance.put(`/airlineticket/${id}`, ticket, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
}