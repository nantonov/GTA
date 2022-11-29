export enum ModalActionTypes {
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

export function showUpdateModal(): ModalAction {
  return {
    type: ModalActionTypes.ShowUpdateModal,
  };
}

export function hideUpdateModal(): ModalAction {
  return {
    type: ModalActionTypes.HideUpdateModal,
  };
}

export function showCreateModal(): ModalAction {
  return {
    type: ModalActionTypes.ShowCreateModal,
  };
}

export function hideCreateModal(): ModalAction {
  return {
    type: ModalActionTypes.HideCreateModal,
  };
}

export function showDeleteModal(): ModalAction {
  return {
    type: ModalActionTypes.ShowCreateModal,
  };
}

export function hideDeleteModal(): ModalAction {
  return {
    type: ModalActionTypes.HideCreateModal,
  };
}
