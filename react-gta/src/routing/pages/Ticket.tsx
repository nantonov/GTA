import {
  TableContainer,
  Paper,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
} from '@mui/material';
import React from 'react';
import { useParams } from 'react-router-dom';
import { ITicketGetModel } from '../../modelInterfaces/getInterfaces/ITicketGetModel';

const Ticket = (props: { tickets: ITicketGetModel[] }) => {
  const { ticketId } = useParams();
  const ticket = props.tickets.find(({ id }) => id === Number(ticketId));
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
            </TableRow>
          </TableHead>
          <TableBody>
            <TableRow key={ticket?.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
              <TableCell component="th" scope="row">
                {ticket?.id}
              </TableCell>
              <TableCell align="right">{String(ticket?.departureTime)}</TableCell>
              <TableCell align="right">{String(ticket?.arrivalTime)}</TableCell>
              <TableCell align="right">{ticket?.price}</TableCell>
              <TableCell align="right">{ticket?.passengerCredentials}</TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </TableContainer>
    </div>
  );
};

export default Ticket;
