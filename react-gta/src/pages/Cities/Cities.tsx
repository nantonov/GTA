import React from 'react';
import PagesCityInput from '../../core/components/inputs/PagesCityInput';
import PagesCityTable from '../../core/components/tables/PagesCityTable';
import PagesModalWrapper from '../../core/components/appModalWrapper/AppModalWrapper';
import { useSelector } from 'react-redux';
import { ModalActionTypes } from '../../core/redux/actionTypes/modalTypes';
import { RootState } from '../../core/redux/reducers/rootReducer';
import { useDispatch } from 'react-redux';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import Button from '@mui/material/Button';

const Cities = () => {
  const openModal = useSelector((state: RootState) => state.modal);
  const dispatch = useDispatch();

  return (
    <div>
      <PagesModalWrapper
        open={openModal.createModal}
        onClose={() => dispatch({ type: ModalActionTypes.HideCreateModal })}
      >
        <PagesCityInput creatingInput={true} id={0} />
      </PagesModalWrapper>
      <Button
        variant="outlined"
        onClick={() => dispatch({ type: ModalActionTypes.ShowCreateModal })}
        startIcon={<AddCircleIcon />}
      >
        Create a new city
      </Button>

      <PagesCityTable />
    </div>
  );
};

export default Cities;
