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
import TicketCityGetModel from '../../core/interfaces/modelnterfaces/getInterfaces/ticketCityGetModel';

const TicketCity = (props: { ticketCities: TicketCityGetModel[] }) => {
  const { urlTicketId, urlCityId } = useParams();
  const ticketCity = props.ticketCities.find(
    ({ airlineTicketId, cityId }) =>
      airlineTicketId === Number(urlTicketId) && cityId === Number(urlCityId)
  );

  const ticketId = ticketCity ? ticketCity.airlineTicketId : 1;
  let cityId = ticketCity ? ticketCity.cityId : 2;
  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell width={100}>Ticket ID</TableCell>
              <TableCell width={100}>City ID</TableCell>
              <TableCell align="right">City Staying Status</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            <TableRow
              key={ticketId + cityId}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {ticketCity?.airlineTicketId}
              </TableCell>
              <TableCell align="right">{ticketCity?.cityId}</TableCell>
              <TableCell align="right">{ticketCity?.stayingStatus}</TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </TableContainer>
    </div>
  );
};

export default TicketCity;
