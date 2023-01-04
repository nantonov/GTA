import { AnyAction } from 'redux';
import { ThunkDispatch } from 'redux-thunk';
import { CreateUserTicketModel } from '../../interfaces/modelnterfaces/createUpdateInterfaces/createUserTicketModel';
import {
  addTicketToUserHistoryService,
  deleteUserHistoryService,
  getAllUserHistoriesService,
  getUserHistoryByUserIdService,
  removeTicketFromUserHistoryService,
} from '../../services/HistoryService';
import {
  setHistoryFail,
  setHistoryStart,
  setHistorySuccess,
  setHistorySuccessSeparate,
} from '../actionCreators/historyAction';
import rootReducer from '../reducers/rootReducer';

export const getAllUserHistories =
  () => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setHistoryStart());
      const histories = await getAllUserHistoriesService();
      dispatch(setHistorySuccess(histories));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setHistoryFail(errorMessage));
    }
  };

export const getByUserIdHistory =
  (userId: string) => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setHistoryStart());
      const history = await getUserHistoryByUserIdService(userId);
      dispatch(setHistorySuccessSeparate(history));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setHistoryFail(errorMessage));
    }
  };

export const deleteUserHistory =
  (userId: string) => async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setHistoryStart());
      await deleteUserHistoryService(userId);
      const histories = await getAllUserHistoriesService();
      dispatch(setHistorySuccess(histories));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setHistoryFail(errorMessage));
    }
  };

export const addTicketToUserHistory =
  (ticket: CreateUserTicketModel) =>
  async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setHistoryStart());
      const history = await addTicketToUserHistoryService(ticket);
      dispatch(setHistorySuccessSeparate(history));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setHistoryFail(errorMessage));
    }
  };

export const RemoveTicketFromUserHistory =
  (ticketId: number, userId: string) =>
  async (dispatch: ThunkDispatch<typeof rootReducer, any, AnyAction>) => {
    try {
      dispatch(setHistoryStart());
      const history = await removeTicketFromUserHistoryService(ticketId, userId);
      dispatch(setHistorySuccessSeparate(history));
    } catch (error) {
      const errorMessage = (error as Error).message;
      dispatch(setHistoryFail(errorMessage));
    }
  };
