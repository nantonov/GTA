import { NotificationsAction, NotificationsActionTypes } from '../actionTypes/notificationsTypes';

export const setNotificationsStart = (): NotificationsAction => ({
  type: NotificationsActionTypes.NOTIFICATIONS_START,
});

export const setNotificationsSuccess = (): NotificationsAction => ({
  type: NotificationsActionTypes.NOTIFICATIONS_SUCCESS,
});

export const setNotificationsFail = (error: string): NotificationsAction => ({
  type: NotificationsActionTypes.NOTIFICATIONS_FAIL,
  payload: error,
});
