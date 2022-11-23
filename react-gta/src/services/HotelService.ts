import axios from "axios"
import { axiosConfig } from "../configuration/axiosConfig"; 
import { ICreateUpdateHotelModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateHotelModel";
import IHotelGetModel from "../modelInterfaces/getInterfaces/IHotelGetModel";
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

export default class HotelService {
    static async delete(id: number) {
        const response = await axiosInstance.delete(`/hotel/${id}`)
        return response.data
    }

    static async create(hotel: ICreateUpdateHotelModel) {
        const response = await axiosInstance.post(`/hotel`, hotel, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
    
    static async getAll(): Promise<Array<IHotelGetModel>> {
        const response = await axiosInstance.get(`/hotel`)
        return response.data
    }

    static async update(id: number, hotel: ICreateUpdateHotelModel) {
        const response = await axiosInstance.put(`/hotel/${id}`, hotel, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
}