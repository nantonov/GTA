import axios from "axios"
import { axiosConfig } from "../configuration/axiosConfig"; 
import { ICreateUpdateCityModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateCityModel";
import { ICityGetModel } from "../modelInterfaces/getInterfaces/ICityGetModel";
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

export default class CityService {

    static async delete(id: number) {
        const response = await axiosInstance.delete(`/city/${id}`)
        return response.data
    }

    static async create(city: ICreateUpdateCityModel) {
        const response = await axiosInstance.post(`/city`, city, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
    
    static async getAll() : Promise<Array<ICityGetModel>> {
        const response = await axiosInstance.get(`/city`).then((response) => response.data)
        return response
    }

    static async update(id: number, city: ICreateUpdateCityModel) {
        const response = await axiosInstance.put(`/city/${id}`, city, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
}