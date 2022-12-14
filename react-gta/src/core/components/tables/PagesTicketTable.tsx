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
import PagesTicketInput from '../inputs/PagesTicketInput';
import AppModalWrapper from '../appModalWrapper/AppModalWrapper';
import { RootState } from '../../redux/reducers/rootReducer';
import { useSelector } from 'react-redux';
import { useDispatch } from 'react-redux';
import { ModalActionTypes } from '../../redux/actionTypes/modalTypes';
import PagesTypography from '../appTypography/AppTypography';
import { deleteTicket, getAllTickets } from '../../redux/thunk/ticketThunk';
import { Link } from 'react-router-dom';
import { showUpdateModal } from '../../redux/actionCreators/modalAction';

const PagesTicketTable = () => {
  const [updateTicketId, setUpdateTicketId] = useState(0);
  const [deleteTicketId, setDeleteTicketId] = useState(0);

  const openModal = useSelector((state: RootState) => state.modal);
  const tickets = useSelector((state: RootState) => state.ticket.tickets);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getAllTickets());
  });

  const openEditingTicketModalWindow = async (updateTicketId: number) => {
    dispatch({ type: ModalActionTypes.ShowUpdateModal });
    setUpdateTicketId(updateTicketId);
  };

  const openDeletingTicketModalWindow = (deleteTicketId: number) => {
    setDeleteTicketId(deleteTicketId);
    dispatch({ type: ModalActionTypes.ShowDeleteModal });
  };

  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell width={100}>Id</TableCell>
              <TableCell align="right">Departure time</TableCell>
              <TableCell align="right">Arrival time</TableCell>
              <TableCell align="right">Price</TableCell>
              <TableCell align="right">Passenger credentials</TableCell>
              <TableCell align="right"></TableCell>
              <TableCell align="right"></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tickets.map((ticket) => (
              <TableRow key={ticket.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                <TableCell component="th" scope="row">
                  <Link to={`/ticket/${ticket.id}`}>{ticket.id}</Link>
                </TableCell>
                <TableCell align="right">{String(ticket.departureTime)}</TableCell>
                <TableCell align="right">{String(ticket.arrivalTime)}</TableCell>
                <TableCell align="right">{ticket.price}</TableCell>
                <TableCell align="right">{ticket.passengerCredentials}</TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={async () => openDeletingTicketModalWindow(ticket.id)}
                    startIcon={<DeleteIcon />}
                  >
                    Delete
                  </Button>
                </TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={() => openEditingTicketModalWindow(ticket.id)}
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
      <AppModalWrapper
        open={openModal.updateModal}
        onClose={() => dispatch({ type: ModalActionTypes.HideUpdateModal })}
      >
        <PagesTicketInput creatingInput={false} id={updateTicketId} />
      </AppModalWrapper>
      <AppModalWrapper
        open={openModal.deleteModal}
        onClose={() => {
          dispatch({ type: ModalActionTypes.HideDeleteModal });
        }}
      >
        <PagesTypography align="center">
          <div>Delete the ticket?</div>
          <Button
            variant="outlined"
            onClick={async () => {
              dispatch(deleteTicket(deleteTicketId));
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
      </AppModalWrapper>
    </div>
  );
};

export default PagesTicketTable;
