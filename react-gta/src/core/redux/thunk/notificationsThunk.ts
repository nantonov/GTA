import { AnyAction } from 'redux';
import { ThunkDispatch } from 'redux-thunk';
import { CreateNotificationRequestModel } from '../../interfaces/modelnterfaces/createUpdateInterfaces/createNotificationRequestModel';
import { createNotificationRequestService } from '../../services/NotificationsService';
import {
  setNotificationsStart,
  setNotificationsSuccess,
  setNotificationsFail,
} from '../actionCreators/notificationsAction';
import rootReducer from '../reducers/rootReducer';

export const createNotificationRequest =
  (request: CreateNotificationRequestModel) =>
  async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setNotificationsStart());
      await createNotificationRequestService(request);
      dispatch(setNotificationsSuccess());
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setNotificationsFail(errorMessage));
    }
  };
