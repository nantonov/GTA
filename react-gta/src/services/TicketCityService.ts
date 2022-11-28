import { ICreateUpdateTicketCityModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateTicketCityModel";
import ITicketCityGetModel from "../modelInterfaces/getInterfaces/ITicketCityGetModel";
import UserService from "./UserService";
import axiosInstance from "../instances/axiosInstance"


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

export const getAllTicketCitiesService = async() : Promise<Array<ITicketCityGetModel>> => {
    const response = await axiosInstance.get(`/airlineticketcity`)
    return response.data
}

export const createTicketCityService = async(ticketCity : ICreateUpdateTicketCityModel) : Promise<Array<ITicketCityGetModel>> => {
    const response = await axiosInstance.post(`/airlineticketcity`, ticketCity, {
        headers: {         'Content-Type': 'application/json'     }
    })
    return response.data
}

export const deleteTicketCityService = async(ticketId : number, cityId : number) : Promise<Array<ITicketCityGetModel>> => {
    const response = await axiosInstance.delete(`/airlineticketcity/ticket/${ticketId}/city/${cityId}`)
    return response.data
}

export const updateTicketCityService = async(ticketCity: ICreateUpdateTicketCityModel) : Promise<Array<ITicketCityGetModel>> => {
    const response = await axiosInstance.put(`/airlineticketcity`, ticketCity, {
        headers: {         'Content-Type': 'application/json'     }
    })
    return response.data
}