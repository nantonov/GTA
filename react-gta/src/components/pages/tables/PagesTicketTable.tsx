import React, { useEffect, useState } from "react";
import { Button } from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import TicketService from "../../../services/TicketService";
import { ITicketGetModel } from "../../../modelInterfaces/getInterfaces/ITicketGetModel";
import EditIcon from "@mui/icons-material/Edit";
import PagesTicketInput from "../inputs/PagesTicketInput";
import "./Tables.css";
import PagesModalWrapper from "../PagesModalWrapper";
import { RootState } from "../../../store/reducers";
import { useSelector } from "react-redux";
import { useDispatch } from "react-redux";
import { ModalActionTypes } from "../../../store/modalActions";
import PagesTypography from "../PagesTypography";

const PagesTicketTable = () => {
  const [tickets, setTickets] = useState(new Array<ITicketGetModel>());
  const [updateTicketId, setUpdateTicketId] = useState(0);
  const [deleteTicketId, setDeleteTicketId] = useState(0);

  const openModal = useSelector((state: RootState) => state.modal);
  const dispatch = useDispatch();

  useEffect(() => {
    async function getTickets() {
      const response = await TicketService.getAll();
      setTickets(response);
    }
    getTickets();
  }, [tickets]);

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
              <TableRow
                key={ticket.id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {ticket.id}
                </TableCell>
                <TableCell align="right">
                  {String(ticket.departureTime)}
                </TableCell>
                <TableCell align="right">
                  {String(ticket.arrivalTime)}
                </TableCell>
                <TableCell align="right">{ticket.price}</TableCell>
                <TableCell align="right">
                  {ticket.passengerCredentials}
                </TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={async () =>
                      openDeletingTicketModalWindow(ticket.id)
                    }
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
      <PagesModalWrapper
        open={openModal.updateModal}
        onClose={() => dispatch({ type: ModalActionTypes.HideUpdateModal })}
      >
        <PagesTicketInput creatingInput={false} id={updateTicketId} />
      </PagesModalWrapper>
      <PagesModalWrapper
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
              await TicketService.delete(deleteTicketId);
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

export default PagesTicketTable;
