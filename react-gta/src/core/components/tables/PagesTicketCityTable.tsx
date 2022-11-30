import React, { useEffect, useState } from 'react';
import { Button } from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import EditIcon from '@mui/icons-material/Edit';
import PagesTicketCityInput from '../inputs/PagesTicketCityInput';
import PagesModalWrapper from '../appModalWrapper/AppModalWrapper';
import { useSelector } from 'react-redux';
import { ModalActionTypes } from '../../redux/actionTypes/modalTypes';
import { RootState } from '../../redux/reducers/rootReducer';
import { useDispatch } from 'react-redux';
import PagesTypography from '../appTypography/AppTypography';
import { deleteTicketCity, getAllTicketCities } from '../../redux/thunk/ticketCityThunk';
import { Link } from 'react-router-dom';

const PagesTicketCityTable = () => {
  const [updateTicketId, setUpdateTicketId] = useState(0);
  const [updateCityId, setUpdateCityId] = useState(0);
  const [deleteTicketId, setDeleteTicketId] = useState(0);
  const [deleteCityId, setDeleteCityId] = useState(0);

  const openModal = useSelector((state: RootState) => state.modal);
  const ticketCities = useSelector((state: RootState) => state.ticketCity.ticketCities);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getAllTicketCities());
  });

  const openEditingTicketCityModalWindow = async (updateTicketId: number, updateCityId: number) => {
    dispatch({ type: ModalActionTypes.ShowUpdateModal });
    setUpdateTicketId(updateTicketId);
    setUpdateCityId(updateCityId);
  };

  const openDeletingTicketCityModalWindow = (deleteTicketId: number, deleteCityId: number) => {
    dispatch({ type: ModalActionTypes.ShowDeleteModal });
    setDeleteTicketId(deleteTicketId);
    setDeleteCityId(deleteCityId);
  };

  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell width={100}>Ticket ID</TableCell>
              <TableCell width={100}>City ID</TableCell>
              <TableCell align="right">City Staying Status</TableCell>
              <TableCell align="right"></TableCell>
              <TableCell align="right"></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {ticketCities.map((ticketCity) => (
              <TableRow
                key={ticketCity.airlineTicketId + ticketCity.cityId}
                sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  <Link
                    to={`/ticketCity/ticket/${ticketCity.airlineTicketId}/city/${ticketCity.cityId}`}
                  >
                    {ticketCity.airlineTicketId}
                  </Link>
                </TableCell>
                <TableCell align="right">
                  <Link
                    to={`/ticketCity/ticket/${ticketCity.airlineTicketId}/city/${ticketCity.cityId}`}
                  >
                    {ticketCity.cityId}
                  </Link>
                </TableCell>
                <TableCell align="right">{ticketCity.stayingStatus}</TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={() =>
                      openDeletingTicketCityModalWindow(
                        ticketCity.airlineTicketId,
                        ticketCity.cityId
                      )
                    }
                    startIcon={<DeleteIcon />}
                  >
                    Delete
                  </Button>
                </TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={() =>
                      openEditingTicketCityModalWindow(
                        ticketCity.airlineTicketId,
                        ticketCity.cityId
                      )
                    }
                    startIcon={<EditIcon />}
                  >
                    Edit
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <PagesModalWrapper
        open={openModal.updateModal}
        onClose={() => dispatch({ type: ModalActionTypes.HideUpdateModal })}
      >
        <PagesTicketCityInput
          creatingInput={false}
          ticketId={updateTicketId}
          cityId={updateCityId}
        />
      </PagesModalWrapper>
      <PagesModalWrapper
        open={openModal.deleteModal}
        onClose={() => {
          dispatch({ type: ModalActionTypes.HideDeleteModal });
        }}
      >
        <PagesTypography align="center">
          <div>Delete the ticket-city?</div>
          <Button
            variant="outlined"
            onClick={async () => {
              dispatch(deleteTicketCity(deleteTicketId, deleteCityId));
              dispatch({ type: ModalActionTypes.HideDeleteModal });
            }}
          >
            Yes
          </Button>
          <Button
            variant="outlined"
            onClick={() => dispatch({ type: ModalActionTypes.HideDeleteModal })}
          >
            No
          </Button>
        </PagesTypography>
      </PagesModalWrapper>
    </div>
  );
};

export default PagesTicketCityTable;
