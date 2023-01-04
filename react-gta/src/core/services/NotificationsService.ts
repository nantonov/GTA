import axiosInstance from '../../configuration/axiosInstance';
import { CreateNotificationRequestModel } from '../interfaces/modelnterfaces/createUpdateInterfaces/createNotificationRequestModel';
import { NotificationRequestGetModel } from '../interfaces/modelnterfaces/getInterfaces/notificationRequestGetModel';
import addAxiosInterceptors from './axiosInterceptors';

addAxiosInterceptors();

export const createNotificationRequestService = async (
  request: CreateNotificationRequestModel
): Promise<Array<NotificationRequestGetModel>> => {
  const response = await axiosInstance.post(`/notification/request`, request, {
    headers: { 'Content-Type': 'application/json' },
  });
  return response.data;
};
