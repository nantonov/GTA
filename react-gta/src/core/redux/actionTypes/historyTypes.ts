import { UserTicketsHistoryGetModel } from '../../interfaces/modelnterfaces/getInterfaces/userTicketsHistoryGetModel';

export enum HistoryActionTypes {
  HISTORY_START = 'HISTORY_START',
  HISTORY_SUCCESS = 'HISTORY_SUCCESS',
  HISTORY_SUCCESS_SEPARATE = 'HISTORY_SUCCESS_SEPARATE',
  HISTORY_FAIL = 'HISTORY_FAIL',
}

interface HistoryStartAction {
  type: HistoryActionTypes.HISTORY_START;
}

interface HistorySuccessAction {
  type: HistoryActionTypes.HISTORY_SUCCESS;
  payload: UserTicketsHistoryGetModel[];
}

interface HistorySuccessActionSeparate {
  type: HistoryActionTypes.HISTORY_SUCCESS_SEPARATE;
  payload: UserTicketsHistoryGetModel;
}

interface HistoryFailAction {
  type: HistoryActionTypes.HISTORY_FAIL;
  payload: string;
}

export type HistoryAction =
  | HistoryStartAction
  | HistorySuccessAction
  | HistorySuccessActionSeparate
  | HistoryFailAction;
