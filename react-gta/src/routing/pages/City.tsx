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
import { ICityGetModel } from '../../modelInterfaces/getInterfaces/ICityGetModel';

const City = (props: { cities: ICityGetModel[] }) => {
  const { cityId } = useParams();
  const city = props.cities.find(({ id }) => id === Number(cityId));
  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell width={100}>Id</TableCell>
              <TableCell align="right">Name</TableCell>
              <TableCell align="right">Population</TableCell>
              <TableCell align="right">Area</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            <TableRow key={city?.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
              <TableCell component="th" scope="row">
                {city?.id}
              </TableCell>
              <TableCell align="right">{city?.name}</TableCell>
              <TableCell align="right">{city?.population}</TableCell>
              <TableCell align="right">{city?.area}</TableCell>
            </TableRow>
          </TableBody>
        </Table>
      </TableContainer>
    </div>
  );
};

export default City;
