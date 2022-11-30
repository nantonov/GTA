import { ICreateUpdateTicketModel } from '../modelInterfaces/createUpdateInterfaces/ICreateUpdateTicketModel';
import { ITicketGetModel } from '../modelInterfaces/getInterfaces/ITicketGetModel';
import axiosInstance from '../instances/axiosInstance';
import addAxiosInterceptors from './axiosInterceptors';

addAxiosInterceptors();

export const getAllTicketsService = async (): Promise<Array<ITicketGetModel>> => {
  const response = await axiosInstance.get(`/airlineticket`);
  return response.data;
};

export const createTicketService = async (
  ticket: ICreateUpdateTicketModel
): Promise<Array<ITicketGetModel>> => {
  const response = await axiosInstance.post(`/airlineticket`, ticket, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};

export const deleteTicketService = async (id: number): Promise<Array<ITicketGetModel>> => {
  const response = await axiosInstance.delete(`/airlineticket/${id}`);
  return response.data;
};

export const updateTicketService = async (
  id: number,
  ticket: ICreateUpdateTicketModel
): Promise<Array<ITicketGetModel>> => {
  const response = await axiosInstance.put(`/airlineticket/${id}`, ticket, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};
