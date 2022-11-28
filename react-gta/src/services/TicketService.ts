import { ICreateUpdateTicketModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateTicketModel";
import { ITicketGetModel } from "../modelInterfaces/getInterfaces/ITicketGetModel";
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

export const getAllTicketsService = async() : Promise<Array<ITicketGetModel>> => {
    const response = await axiosInstance.get(`/airlineticket`)
    return response.data
}

export const createTicketService = async(ticket : ICreateUpdateTicketModel) : Promise<Array<ITicketGetModel>> => {
    const response = await axiosInstance.post(`/airlineticket`, ticket, {
        headers: {         'Content-Type': 'application/json'     }
    })
    return response.data
}

export const deleteTicketService = async(id : number) : Promise<Array<ITicketGetModel>> => {
    const response = await axiosInstance.delete(`/airlineticket/${id}`)
    return response.data
}

export const updateTicketService = async(id: number, ticket: ICreateUpdateTicketModel) : Promise<Array<ITicketGetModel>> => {
    const response = await axiosInstance.put(`/airlineticket/${id}`, ticket, {
        headers: {         'Content-Type': 'application/json'     }
    })
    return response.data
}