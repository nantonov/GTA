import PagesTicketCityInput from '../../core/components/inputs/PagesTicketCityInput';
import PagesTicketCityTable from '../../core/components/tables/PagesTicketCityTable';
import AppModalWrapper from '../../core/components/appModalWrapper/AppModalWrapper';
import { useSelector } from 'react-redux';
import { ModalActionTypes } from '../../core/redux/actionTypes/modalTypes';
import { RootState } from '../../core/redux/reducers/rootReducer';
import { useDispatch } from 'react-redux';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import Button from '@mui/material/Button';

const TicketCities = () => {
  const openModal = useSelector((state: RootState) => state.modal);
  const dispatch = useDispatch();

  return (
    <div>
      <AppModalWrapper
        open={openModal.createModal}
        onClose={() => dispatch({ type: ModalActionTypes.HideCreateModal })}
      >
        <PagesTicketCityInput creatingInput={true} ticketId={0} cityId={0} />
      </AppModalWrapper>
      <Button
        variant="outlined"
        onClick={() => dispatch({ type: ModalActionTypes.ShowCreateModal })}
        startIcon={<AddCircleIcon />}
      >
        Create a new ticket-city
      </Button>

      <PagesTicketCityTable />
    </div>
  );
};

export default TicketCities;
