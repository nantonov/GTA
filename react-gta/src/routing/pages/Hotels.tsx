import PagesHotelInput from '../../components/pages/inputs/PagesHotelInput';
import PagesHotelTable from '../../components/pages/tables/PagesHotelTable';
import PagesModalWrapper from '../../components/pages/PagesModalWrapper';
import { useSelector } from 'react-redux';
import { ModalActionTypes } from '../../store/modalActions';
import { RootState } from '../../store/reducers';
import { useDispatch } from 'react-redux';
import AddCircleIcon from '@mui/icons-material/AddCircle';
import Button from '@mui/material/Button';

const Hotels = () => {
  const openModal = useSelector((state: RootState) => state.modal);
  const dispatch = useDispatch();

  return (
    <div>
      <PagesModalWrapper
        open={openModal.createModal}
        onClose={() => dispatch({ type: ModalActionTypes.HideCreateModal })}
      >
        <PagesHotelInput creatingInput={true} id={0} />
      </PagesModalWrapper>
      <Button
        variant="outlined"
        onClick={() => dispatch({ type: ModalActionTypes.ShowCreateModal })}
        startIcon={<AddCircleIcon />}
      >
        Create a new hotel
      </Button>

      <PagesHotelTable />
    </div>
  );
};

export default Hotels;
