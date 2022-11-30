import PagesHotelInput from '../../core/components/inputs/PagesHotelInput';
import PagesHotelTable from '../../core/components/tables/PagesHotelTable';
import PagesModalWrapper from '../../core/components/appModalWrapper/AppModalWrapper';
import { useSelector } from 'react-redux';
import { ModalActionTypes } from '../../core/redux/actionTypes/modalTypes';
import { RootState } from '../../core/redux/reducers/rootReducer';
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
