import React, { useState } from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import TicketCityService from '../../../services/TicketCityService';
import ITicketCityGetModel from '../../../modelInterfaces/getInterfaces/ITicketCityGetModel';

const PagesTicketCityTable = () => {

    const [ticketCities, setTicketCities] = useState(new Array<ITicketCityGetModel>())

    const getTicketCities = async () => {
        const response = await TicketCityService.getAll()
        setTicketCities(response)
    }

    getTicketCities()

    return (
        <div>
            <TableContainer component={Paper}>
                <Table sx={{ minWidth: 650 }} aria-label="simple table">
                    <TableHead>
                    <TableRow>
                        <TableCell width={100}>Ticket ID</TableCell>
                        <TableCell width= {100}>City ID</TableCell>
                        <TableCell align="right">City Staying Status</TableCell>
                    </TableRow>
                    </TableHead>
                    <TableBody>
                    {
                        ticketCities.map((ticketCity) => (
                        <TableRow
                        key={ticketCity.airlineTicketId + ticketCity.cityId + Math.random()}
                        sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                        >
                        <TableCell component="th" scope="row">
                            {ticketCity.airlineTicketId}
                        </TableCell>
                        <TableCell align="right">
                            {ticketCity.cityId}
                        </TableCell>
                        <TableCell align="right">{ticketCity.stayingStatus}</TableCell>
                        </TableRow>
                    ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    );
};

export default PagesTicketCityTable;