import { Button, TextField } from '@mui/material';
import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { CreateUpdateTicketModel } from '../../interfaces/modelnterfaces/createUpdateInterfaces/createUpdateTicketModel';
import { CreateUserTicketModel } from '../../interfaces/modelnterfaces/createUpdateInterfaces/createUserTicketModel';
import { RootState } from '../../redux/reducers/rootReducer';
import { addTicketToUserHistory } from '../../redux/thunk/historyThunk';
import { postTicket } from '../../redux/thunk/ticketThunk';
import PagesTypography from '../appTypography/AppTypography';

const PagesHistoryTicketInput = ({ userName }: { userName: string | undefined }) => {
  const [ticket, setTicket] = useState({
    departureTime: '',
    arrivalTime: '',
    price: '',
    passengerCredentials: '',
  });
  const dispatch = useDispatch();
  const tickets = useSelector((state: RootState) => state.ticket.tickets);

  const addTicket = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const ticketToCreate: CreateUpdateTicketModel = {
      departureTime: ticket.departureTime,
      arrivalTime: ticket.arrivalTime,
      price: Number(ticket.price),
      passengerCredentials: ticket.passengerCredentials,
    };
    dispatch(postTicket(ticketToCreate));

    var newTicket = tickets.find((ticket) => {
      String(ticket.arrivalTime) == ticketToCreate.arrivalTime &&
        String(ticket.departureTime) == ticketToCreate.departureTime &&
        ticket.price == ticketToCreate.price &&
        ticket.passengerCredentials == ticketToCreate.passengerCredentials;
    });
    var ticketToHistory: CreateUserTicketModel = {
      userId: userName ?? '',
      ticketId: newTicket?.id ?? 11,
      arrivalTime: newTicket?.arrivalTime ?? new Date(),
      departureTime: newTicket?.departureTime ?? new Date(),
      price: newTicket?.price ?? 1,
      passengerCredentials: newTicket?.passengerCredentials ?? '',
    };
    dispatch(addTicketToUserHistory(ticketToHistory));

    setTicket({
      departureTime: '',
      arrivalTime: '',
      price: '',
      passengerCredentials: '',
    });
  };
  return (
    <div>
      <form>
        <div>
          <PagesTypography>Add new ticket to your history</PagesTypography>
          <div>
            <TextField
              name="departureTime"
              value={ticket.departureTime}
              type="datetime-local"
              id="outlined-basic"
              label="Departure Time"
              variant="outlined"
              onChange={(e) => setTicket({ ...ticket, departureTime: e.target.value })}
            />

            <TextField
              name="arrivalTime"
              value={ticket.arrivalTime}
              type="datetime-local"
              id="outlined-basic"
              label="Arrival Time"
              variant="outlined"
              onChange={(e) => setTicket({ ...ticket, arrivalTime: e.target.value })}
            />

            <TextField
              name="price"
              value={ticket.price}
              type="number"
              id="outlined-basic"
              label="Price"
              variant="outlined"
              onChange={(e) => setTicket({ ...ticket, price: e.target.value })}
            />

            <TextField
              name="passengerCredentials"
              value={ticket.passengerCredentials}
              id="outlined-basic"
              label="Passenger Credentials"
              variant="outlined"
              onChange={(e) => setTicket({ ...ticket, passengerCredentials: e.target.value })}
            />
          </div>
          <div style={{ margin: '10px 280px' }}>
            <Button type="submit" onClick={addTicket} variant="contained">
              {'Add the ticket'}
            </Button>
          </div>
        </div>
      </form>
    </div>
  );
};

export default PagesHistoryTicketInput;
