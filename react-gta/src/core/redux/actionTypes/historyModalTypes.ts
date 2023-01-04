export enum HistoryModalActionTypes {
  ShowModal,
  HideModal,
  ShowIdModal,
  HideIdModal,
  ShowCreateModal,
  HideCreateModal,
}

export interface HistoryModalAction {
  type: HistoryModalActionTypes;
  payload?: any;
}
