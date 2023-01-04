export enum NotificationsActionTypes {
  NOTIFICATIONS_START = 'NOTIFICATIONS_START',
  NOTIFICATIONS_SUCCESS = 'NOTIFICATIONS_SUCCESS',
  NOTIFICATIONS_FAIL = 'NOTIFICATIONS_FAIL',
}

interface NotificationsStartAction {
  type: NotificationsActionTypes.NOTIFICATIONS_START;
}

interface NotificationsSuccessAction {
  type: NotificationsActionTypes.NOTIFICATIONS_SUCCESS;
}

interface NotificationsFailAction {
  type: NotificationsActionTypes.NOTIFICATIONS_FAIL;
  payload: string;
}

export type NotificationsAction =
  | NotificationsStartAction
  | NotificationsSuccessAction
  | NotificationsFailAction;
