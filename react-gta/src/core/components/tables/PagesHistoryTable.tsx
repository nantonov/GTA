import {
  Link,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from '@mui/material';
import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { RootState } from '../../redux/reducers/rootReducer';
import { getByUserIdHistory } from '../../redux/thunk/historyThunk';

const PagesHistoryTable = ({ userName }: { userName: string | undefined }) => {
  const userHistory = useSelector((state: RootState) => state.history.history);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getByUserIdHistory(userName ?? ''));
  });

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
            {userHistory &&
              userHistory?.airlineTickets.map((ticket) => (
                <TableRow
                  key={ticket.ticketId}
                  sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                >
                  <TableCell component="th" scope="row">
                    {ticket.ticketId}
                  </TableCell>
                  <TableCell align="right">{String(ticket.departureTime)}</TableCell>
                  <TableCell align="right">{String(ticket.arrivalTime)}</TableCell>
                  <TableCell align="right">{ticket.price}</TableCell>
                  <TableCell align="right">{ticket.passengerCredentials}</TableCell>
                </TableRow>
              ))}
          </TableBody>
        </Table>
      </TableContainer>
    </div>
  );
};

export default PagesHistoryTable;
