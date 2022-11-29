import { ICreateUpdateCityModel } from '../modelInterfaces/createUpdateInterfaces/ICreateUpdateCityModel';
import { ICityGetModel } from '../modelInterfaces/getInterfaces/ICityGetModel';
import UserService from './UserService';
import axiosInstance from '../instances/axiosInstance';

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

export const getAllCitiesService = async (): Promise<Array<ICityGetModel>> => {
  const response = await axiosInstance.get(`/city`).then((response) => response.data);
  return response;
};

export const createCityService = async (
  city: ICreateUpdateCityModel
): Promise<Array<ICityGetModel>> => {
  const response = await axiosInstance.post(`/city`, city, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};

export const deleteCityService = async (id: number): Promise<Array<ICityGetModel>> => {
  const response = await axiosInstance.delete(`/city/${id}`);
  return response.data;
};

export const updateCityService = async (
  id: number,
  city: ICreateUpdateCityModel
): Promise<Array<ICityGetModel>> => {
  const response = await axiosInstance.put(`/city/${id}`, city, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};
