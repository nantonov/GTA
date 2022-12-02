import { CreateUpdateCityModel } from '../interfaces/modelnterfaces/createUpdateInterfaces/createUpdateCityModel';
import { CityGetModel } from '../interfaces/modelnterfaces/getInterfaces/cityGetModel';
import axiosInstance from '../../configuration/axiosInstance';
import addAxiosInterceptors from './axiosInterceptors';

addAxiosInterceptors();

export const getAllCitiesService = async (): Promise<Array<CityGetModel>> => {
  const response = await axiosInstance.get(`/city`).then((response) => response.data);
  return response;
};

export const createCityService = async (
  city: CreateUpdateCityModel
): Promise<Array<CityGetModel>> => {
  const response = await axiosInstance.post(`/city`, city, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};

export const deleteCityService = async (id: number): Promise<Array<CityGetModel>> => {
  const response = await axiosInstance.delete(`/city/${id}`);
  return response.data;
};

export const updateCityService = async (
  id: number,
  city: CreateUpdateCityModel
): Promise<Array<CityGetModel>> => {
  const response = await axiosInstance.put(`/city/${id}`, city, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};
