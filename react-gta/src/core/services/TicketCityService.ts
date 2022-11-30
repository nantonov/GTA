import { CreateUpdateTicketCityModel } from '../interfaces/modelnterfaces/createUpdateInterfaces/createUpdateTicketCityModel';
import TicketCityGetModel from '../interfaces/modelnterfaces/getInterfaces/ticketCityGetModel';
import axiosInstance from '../../configuration/axiosInstance';
import addAxiosInterceptors from './axiosInterceptors';

addAxiosInterceptors();

export const getAllTicketCitiesService = async (): Promise<Array<TicketCityGetModel>> => {
  const response = await axiosInstance.get(`/airlineticketcity`);
  return response.data;
};

export const createTicketCityService = async (
  ticketCity: CreateUpdateTicketCityModel
): Promise<Array<TicketCityGetModel>> => {
  const response = await axiosInstance.post(`/airlineticketcity`, ticketCity, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};

export const deleteTicketCityService = async (
  ticketId: number,
  cityId: number
): Promise<Array<TicketCityGetModel>> => {
  const response = await axiosInstance.delete(
    `/airlineticketcity/ticket/${ticketId}/city/${cityId}`
  );
  return response.data;
};

export const updateTicketCityService = async (
  ticketCity: CreateUpdateTicketCityModel
): Promise<Array<TicketCityGetModel>> => {
  const response = await axiosInstance.put(`/airlineticketcity`, ticketCity, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};
