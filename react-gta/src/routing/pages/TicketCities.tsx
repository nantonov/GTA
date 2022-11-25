import PagesTicketCityInput from "../../components/pages/inputs/PagesTicketCityInput";
import PagesTicketCityTable from "../../components/pages/tables/PagesTicketCityTable";
import PagesModalWrapper from "../../components/pages/PagesModalWrapper";
import { useSelector } from "react-redux";
import { ModalActionTypes } from "../../store/modalActions";
import { RootState } from "../../store/reducers";
import { useDispatch } from "react-redux";
import AddCircleIcon from "@mui/icons-material/AddCircle";
import Button from "@mui/material/Button";

const TicketCities = () => {
  const openModal = useSelector((state: RootState) => state.modal);
  const dispatch = useDispatch();

  return (
    <div>
      <PagesModalWrapper
        open={openModal.createModal}
        onClose={() => dispatch({ type: ModalActionTypes.HideCreateModal })}
      >
        <PagesTicketCityInput creatingInput={true} ticketId={0} cityId={0} />
      </PagesModalWrapper>
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
