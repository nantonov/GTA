import { ICreateUpdateHotelModel } from '../modelInterfaces/createUpdateInterfaces/ICreateUpdateHotelModel';
import IHotelGetModel from '../modelInterfaces/getInterfaces/IHotelGetModel';
import axiosInstance from '../instances/axiosInstance';
import addAxiosInterceptors from './axiosInterceptors';

addAxiosInterceptors();

export const getAllHotelsService = async (): Promise<Array<IHotelGetModel>> => {
  const response = await axiosInstance.get(`/hotel`);
  return response.data;
};

export const createHotelService = async (
  hotel: ICreateUpdateHotelModel
): Promise<Array<IHotelGetModel>> => {
  const response = await axiosInstance.post(`/hotel`, hotel, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};

export const deleteHotelService = async (id: number): Promise<Array<IHotelGetModel>> => {
  const response = await axiosInstance.delete(`/hotel/${id}`);
  return response.data;
};

export const updateHotelService = async (
  id: number,
  hotel: ICreateUpdateHotelModel
): Promise<Array<IHotelGetModel>> => {
  const response = await axiosInstance.put(`/hotel/${id}`, hotel, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};
