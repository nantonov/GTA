import axios from "axios"
import { axiosConfig } from "../configuration/axiosConfig"; 
import { ICreateUpdateCityModel } from "../modelInterfaces/createUpdateInterfaces/ICreateUpdateCityModel";
import { ICityGetModel } from "../modelInterfaces/getInterfaces/ICityGetModel";

export default class CityService {
    static async delete(id: number) {
        const response = await axios.delete(`${axiosConfig.ticketsAPIUrl}/city/${id}`)
        return response.data
    }

    static async create(city: ICreateUpdateCityModel) {
        const response = await axios.post(`${axiosConfig.ticketsAPIUrl}/city`, city, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
    
    static async getAll() : Promise<Array<ICityGetModel>> {
        const response = await axios.get(`${axiosConfig.ticketsAPIUrl}/city`).then((response) => response.data)
        return response
    }

    static async update(id: number, city: ICreateUpdateCityModel) {
        const response = await axios.put(`${axiosConfig.ticketsAPIUrl}/city/${id}`, city, {
            headers: {         'Content-Type': 'application/json'     }
        })
        return response.data
    }
}