import { CreateUpdateTicketModel } from '../interfaces/modelnterfaces/createUpdateInterfaces/createUpdateTicketModel';
import { TicketGetModel } from '../interfaces/modelnterfaces/getInterfaces/ticketGetModel';
import axiosInstance from '../../configuration/axiosInstance';
import addAxiosInterceptors from './axiosInterceptors';

addAxiosInterceptors();

export const getAllTicketsService = async (): Promise<Array<TicketGetModel>> => {
  const response = await axiosInstance.get(`/airlineticket`);
  return response.data;
};

export const getTicketByIdService = async (id: number): Promise<TicketGetModel> => {
  const response = await axiosInstance.get(`/airlineticket/${id}`);
  return response.data;
};

export const createTicketService = async (
  ticket: CreateUpdateTicketModel
): Promise<Array<TicketGetModel>> => {
  const response = await axiosInstance.post(`/airlineticket`, ticket, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};

export const deleteTicketService = async (id: number): Promise<Array<TicketGetModel>> => {
  const response = await axiosInstance.delete(`/airlineticket/${id}`);
  return response.data;
};

export const updateTicketService = async (
  id: number,
  ticket: CreateUpdateTicketModel
): Promise<Array<TicketGetModel>> => {
  const response = await axiosInstance.put(`/airlineticket/${id}`, ticket, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};
