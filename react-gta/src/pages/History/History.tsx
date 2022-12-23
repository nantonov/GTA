import { Button } from '@mui/material';
import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import AppModalWrapper from '../../core/components/appModalWrapper/AppModalWrapper';
import PagesTicketInput from '../../core/components/inputs/PagesTicketInput';
import PagesHistoryTable from '../../core/components/tables/PagesHistoryTable';
import { ModalActionTypes } from '../../core/redux/actionTypes/modalTypes';
import { RootState } from '../../core/redux/reducers/rootReducer';
import AddCircleIcon from '@mui/icons-material/AddCircle';

const History = () => {
  const openModal = useSelector((state: RootState) => state.modal);
  const dispatch = useDispatch();

  return (
    <div>
      <AppModalWrapper
        open={openModal.createModal}
        onClose={() => dispatch({ type:  })}
      >
        < />
      </AppModalWrapper>
      <Button
        variant="outlined"
        onClick={() => dispatch({ type:  })}
        startIcon={<AddCircleIcon />}
      >
        Create a new ticket
      </Button>
      
      <AppModalWrapper
        open={openModal.createModal}
        onClose={() => dispatch({ type:  })}
      >
        <PagesTicketInput creatingInput={true} id={0} />
      </AppModalWrapper>
      <Button
        variant="outlined"
        onClick={() => dispatch({ type:  })}
        startIcon={<AddCircleIcon />}
      >
        Create a new ticket
      </Button>
      
      <PagesHistoryTable />
    </div>
  );
};

export default History;
