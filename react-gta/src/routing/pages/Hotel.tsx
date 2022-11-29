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
import IHotelGetModel from '../../modelInterfaces/getInterfaces/IHotelGetModel';

const Hotel = (props: { hotels: IHotelGetModel[] }) => {
  const { hotelId } = useParams();
  const hotel = props.hotels.find(({ id }) => id === Number(hotelId));
  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell width={100}>Id</TableCell>
              <TableCell align="right">Name</TableCell>
              <TableCell align="right">Stars Number</TableCell>
              <TableCell align="right">RoomsNumber</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            <TableRow key={hotel?.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
              <TableCell component="th" scope="row">
                {hotel?.id}
              </TableCell>
              <TableCell align="right">{hotel?.name}</TableCell>
              <TableCell align="right">{hotel?.starsNumber}</TableCell>
              <TableCell align="right">{hotel?.roomsNumber}</TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </TableContainer>
    </div>
  );
};

export default Hotel;
