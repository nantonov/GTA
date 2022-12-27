import { HistoryModalAction, HistoryModalActionTypes } from '../actionTypes/historyModalTypes';

export function showIdModal(): HistoryModalAction {
  return {
    type: HistoryModalActionTypes.ShowIdModal,
  };
}

export function hideIdModal(): HistoryModalAction {
  return {
    type: HistoryModalActionTypes.HideIdModal,
  };
}

export function showCreateModal(): HistoryModalAction {
  return {
    type: HistoryModalActionTypes.ShowCreateModal,
  };
}

export function hideCreateModal(): HistoryModalAction {
  return {
    type: HistoryModalActionTypes.HideCreateModal,
  };
}
