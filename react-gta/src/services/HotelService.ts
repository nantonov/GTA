import { ICreateUpdateHotelModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateHotelModel";
import IHotelGetModel from "../modelInterfaces/getInterfaces/IHotelGetModel";
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

export const getAllHotelsService = async() : Promise<Array<IHotelGetModel>> => {
    const response = await axiosInstance.get(`/hotel`)
    return response.data
}

export const createHotelService = async(hotel : ICreateUpdateHotelModel) : Promise<Array<IHotelGetModel>> => {
    const response = await axiosInstance.post(`/hotel`, hotel, {
        headers: {         'Content-Type': 'application/json'     }
    })
    return response.data
}

export const deleteHotelService = async(id : number) : Promise<Array<IHotelGetModel>> => {
    const response = await axiosInstance.delete(`/hotel/${id}`)
    return response.data
}

export const updateHotelService = async(id: number, hotel: ICreateUpdateHotelModel) : Promise<Array<IHotelGetModel>> => {
    const response = await axiosInstance.put(`/hotel/${id}`, hotel, {
        headers: {         'Content-Type': 'application/json'     }
    })
    return response.data
}