import PagesTicketInput from '../../core/components/inputs/PagesTicketInput';
import PagesTicketTable from '../../core/components/tables/PagesTicketTable';
import AppModalWrapper from '../../core/components/appModalWrapper/AppModalWrapper';
import { useSelector } from 'react-redux';
import { ModalActionTypes } from '../../core/redux/actionTypes/modalTypes';
import { RootState } from '../../core/redux/reducers/rootReducer';
import { useDispatch } from 'react-redux';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import Button from '@mui/material/Button';

const Tickets = () => {
  const openModal = useSelector((state: RootState) => state.modal);
  const dispatch = useDispatch();

  return (
    <div>
      <AppModalWrapper
        open={openModal.createModal}
        onClose={() => dispatch({ type: ModalActionTypes.HideCreateModal })}
      >
        <PagesTicketInput creatingInput={true} id={0} />
      </AppModalWrapper>
      <Button
        variant="outlined"
        onClick={() => dispatch({ type: ModalActionTypes.ShowCreateModal })}
        startIcon={<AddCircleIcon />}
      >
        Create a new ticket
      </Button>

      <PagesTicketTable />
    </div>
  );
};

export default Tickets;
