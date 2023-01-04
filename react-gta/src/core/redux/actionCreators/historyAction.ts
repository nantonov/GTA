import { UserTicketsHistoryGetModel } from '../../interfaces/modelnterfaces/getInterfaces/userTicketsHistoryGetModel';
import { HistoryAction, HistoryActionTypes } from '../actionTypes/historyTypes';

export const setHistoryStart = (): HistoryAction => ({
  type: HistoryActionTypes.HISTORY_START,
});

export const setHistorySuccessSeparate = (history: UserTicketsHistoryGetModel): HistoryAction => ({
  type: HistoryActionTypes.HISTORY_SUCCESS_SEPARATE,
  payload: history,
});

export const setHistorySuccess = (histories: UserTicketsHistoryGetModel[]): HistoryAction => ({
  type: HistoryActionTypes.HISTORY_SUCCESS,
  payload: histories,
});

export const setHistoryFail = (error: string): HistoryAction => ({
  type: HistoryActionTypes.HISTORY_FAIL,
  payload: error,
});
