import { NotificationsAction, NotificationsActionTypes } from '../actionTypes/notificationsTypes';

export interface InitNotificationsState {
  isLoading: boolean;
  error: string | null;
}

const initialState: InitNotificationsState = {
  isLoading: false,
  error: null,
};

const notificationsReducer = (
  state = initialState,
  action: NotificationsAction
): InitNotificationsState => {
  switch (action.type) {
    case NotificationsActionTypes.NOTIFICATIONS_START:
      return {
        ...state,
        isLoading: true,
      };
    case NotificationsActionTypes.NOTIFICATIONS_SUCCESS:
      return {
        ...state,
        isLoading: false,
      };
    case NotificationsActionTypes.NOTIFICATIONS_FAIL:
      return {
        ...state,
        isLoading: false,
        error: action.payload,
      };
    default:
      return state;
  }
};

export default notificationsReducer;
