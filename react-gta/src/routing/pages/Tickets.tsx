import PagesTicketInput from '../../components/pages/inputs/PagesTicketInput';
import PagesTicketTable from '../../components/pages/tables/PagesTicketTable';
import PagesModalWrapper from '../../components/pages/PagesModalWrapper';
import { useSelector } from 'react-redux';
import { ModalActionTypes } from '../../store/modalActions';
import { RootState } from '../../store/reducers';
import { useDispatch } from 'react-redux';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import Button from '@mui/material/Button';

const Tickets = () => {
  const openModal = useSelector((state: RootState) => state.modal);
  const dispatch = useDispatch();

  return (
    <div>
      <PagesModalWrapper
        open={openModal.createModal}
        onClose={() => dispatch({ type: ModalActionTypes.HideCreateModal })}
      >
        <PagesTicketInput creatingInput={true} id={0} />
      </PagesModalWrapper>
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
