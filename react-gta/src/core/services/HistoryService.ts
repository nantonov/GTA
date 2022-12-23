import axiosInstance from '../../configuration/axiosInstance';
import { CreateUserTicketModel } from '../interfaces/modelnterfaces/createUpdateInterfaces/createUserTicketModel';
import { UserTicketsHistoryGetModel } from '../interfaces/modelnterfaces/getInterfaces/userTicketsHistoryGetModel';
import addAxiosInterceptors from './axiosInterceptors';

addAxiosInterceptors();

export const getAllService = async (): Promise<Array<UserTicketsHistoryGetModel>> => {
  const response = await axiosInstance.get(`/history`);
  return response.data;
};

export const getByUserIdService = async (userId: string): Promise<UserTicketsHistoryGetModel> => {
  const response = await axiosInstance.get(`/history/${userId}`);
  return response.data;
};

export const deleteService = async (userId: string): Promise<void> => {
  const response = await axiosInstance.delete(`/history/${userId}`);
  return response.data;
};

export const addTicketToUserHistoryService = async (
  ticket: CreateUserTicketModel
): Promise<UserTicketsHistoryGetModel> => {
  const response = await axiosInstance.post(`/history/ticket`, ticket, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};

export const removeTicketFromUserHistoryService = async (
  ticketId: number,
  userId: string
): Promise<UserTicketsHistoryGetModel> => {
  const response = await axiosInstance.delete(`/history/ticket/${ticketId}/user/${userId}`);
  return response.data;
};
