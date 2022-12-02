import { CreateUpdateHotelModel } from '../interfaces/modelnterfaces/createUpdateInterfaces/createUpdateHotelModel';
import HotelGetModel from '../interfaces/modelnterfaces/getInterfaces/hotelGetModel';
import axiosInstance from '../../configuration/axiosInstance';
import addAxiosInterceptors from './axiosInterceptors';

addAxiosInterceptors();

export const getAllHotelsService = async (): Promise<Array<HotelGetModel>> => {
  const response = await axiosInstance.get(`/hotel`);
  return response.data;
};

export const createHotelService = async (
  hotel: CreateUpdateHotelModel
): Promise<Array<HotelGetModel>> => {
  const response = await axiosInstance.post(`/hotel`, hotel, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};

export const deleteHotelService = async (id: number): Promise<Array<HotelGetModel>> => {
  const response = await axiosInstance.delete(`/hotel/${id}`);
  return response.data;
};

export const updateHotelService = async (
  id: number,
  hotel: CreateUpdateHotelModel
): Promise<Array<HotelGetModel>> => {
  const response = await axiosInstance.put(`/hotel/${id}`, hotel, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};
