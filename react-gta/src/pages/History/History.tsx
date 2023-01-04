import { Button } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import AppModalWrapper from '../../core/components/appModalWrapper/AppModalWrapper';
import PagesHistoryTable from '../../core/components/tables/PagesHistoryTable';
import { RootState } from '../../core/redux/reducers/rootReducer';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import UserService from '../../core/services/UserService';
import PagesHistoryTicketInput from '../../core/components/inputs/PagesHistoryTicketInput';
import PagesHistoryTicketByIdInput from '../../core/components/inputs/PagesHistoryTicketByIdInput';
import { HistoryModalActionTypes } from '../../core/redux/actionTypes/historyModalTypes';

const History = () => {
  const modal = useSelector((state: RootState) => state.historyModal);
  const [userName, setUserName] = useState<string | undefined>('');
  const dispatch = useDispatch();

  useEffect(() => {
    const getUser = async () => {
      const user = await UserService.getUser();
      setUserName(user?.profile.name);
    };

    setTimeout(() => getUser(), 250);
  }, [dispatch]);

  return (
    <div>
      <AppModalWrapper
        open={modal.idModal}
        onClose={() => dispatch({ type: HistoryModalActionTypes.HideIdModal })}
      >
        <PagesHistoryTicketByIdInput userName={userName} />
      </AppModalWrapper>
      <Button
        variant="outlined"
        onClick={() => dispatch({ type: HistoryModalActionTypes.ShowIdModal })}
        startIcon={<AddCircleIcon />}
      >
        Add a ticket via Id
      </Button>

      <AppModalWrapper
        open={modal.createModal}
        onClose={() => dispatch({ type: HistoryModalActionTypes.HideCreateModal })}
      >
        <PagesHistoryTicketInput userName={userName} />
      </AppModalWrapper>
      <Button
        variant="outlined"
        onClick={() => dispatch({ type: HistoryModalActionTypes.ShowCreateModal })}
        startIcon={<AddCircleIcon />}
      >
        Create a new ticket
      </Button>

      <PagesHistoryTable userName={userName} />
    </div>
  );
};

export default History;
