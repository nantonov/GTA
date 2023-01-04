import React, { useReducer, useState } from 'react';
import { useDispatch } from 'react-redux';
import { TicketGetModel } from '../../interfaces/modelnterfaces/getInterfaces/ticketGetModel';
import { getTicketById } from '../../redux/thunk/ticketThunk';
import store from '../../redux/store';
import { addTicketToUserHistoryService } from '../../services/HistoryService';
import { CreateUserTicketModel } from '../../interfaces/modelnterfaces/createUpdateInterfaces/createUserTicketModel';
import PagesTypography from '../appTypography/AppTypography';
import { Button, TextField } from '@mui/material';
import { addTicketToUserHistory } from '../../redux/thunk/historyThunk';

const PagesHistoryTicketByIdInput = ({ userName }: { userName: string | undefined }) => {
  const [ticketId, setTicketId] = useState('');
  const dispatch = useDispatch();

  const addTicket = (e: React.SyntheticEvent) => {
    e.preventDefault();
    dispatch(getTicketById(Number(ticketId)));
    const ticketToAdd = store.getState().ticket.ticket;
    var userTicketModel: CreateUserTicketModel = {
      userId: userName ?? '',
      ticketId: Number(ticketId),
      departureTime: ticketToAdd?.departureTime ?? new Date(),
      arrivalTime: ticketToAdd?.arrivalTime ?? new Date(),
      price: ticketToAdd?.price ?? 100,
      passengerCredentials: ticketToAdd?.passengerCredentials ?? '',
    };

    dispatch(addTicketToUserHistory(userTicketModel));
    setTicketId('');
  };

  return (
    <div>
      <form>
        <PagesTypography>Add existing ticket to your history by ticket Id</PagesTypography>
        <div>
          <TextField
            name="ticketId"
            value={ticketId}
            type="number"
            id="outlined-basic"
            label="Ticket Id"
            variant="outlined"
            onChange={(e) => setTicketId(e.target.value)}
          />
        </div>
        <div style={{ margin: '10px' }}>
          <Button type="submit" onClick={addTicket} variant="contained">
            {'Add the ticket'}
          </Button>
        </div>
      </form>
    </div>
  );
};

export default PagesHistoryTicketByIdInput;
