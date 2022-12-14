export enum ModalActionTypes {
  ShowModal,
  HideModal,
  ShowUpdateModal,
  HideUpdateModal,
  ShowCreateModal,
  HideCreateModal,
  ShowDeleteModal,
  HideDeleteModal,
}

export interface ModalAction {
  type: ModalActionTypes;
  payload?: any;
}
