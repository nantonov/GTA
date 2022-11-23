import axios from "axios"
import { axiosConfig } from "../configuration/axiosConfig"; 
import { ICreateUpdateTicketCityModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateTicketCityModel";
import ITicketCityGetModel from "../modelInterfaces/getInterfaces/ITicketCityGetModel";
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

export default class TicketCityService {
    static async delete(ticketId: number, cityId: number) {
        const response = await axiosInstance.delete(`/airlineticketcity/ticket/${ticketId}/city/${cityId}`)
        return response.data
    }

    static async create(ticketCity: ICreateUpdateTicketCityModel) {
        const response = await axiosInstance.post(`/airlineticketcity`, ticketCity, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
    
    static async getAll(): Promise<Array<ITicketCityGetModel>> {
        const response = await axiosInstance.get(`/airlineticketcity`)
        return response.data
    }

    static async update(ticketCity: ICreateUpdateTicketCityModel) {
        const response = await axiosInstance.put(`/airlineticketcity`, ticketCity, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
}