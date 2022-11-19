import React, { useState } from 'react';
import { Button } from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
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

    const deleteTicketCity = async (ticketId : number, cityId: number) => {
        await TicketCityService.delete(ticketId, cityId)
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
                        <TableCell align="right"></TableCell>
                    </TableRow>
                    </TableHead>
                    <TableBody>
                    {
                        ticketCities.map((ticketCity) => (
                        <TableRow
                        key={ticketCity.airlineTicketId + ticketCity.cityId}
                        sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                        >
                        <TableCell component="th" scope="row">
                            {ticketCity.airlineTicketId}
                        </TableCell>
                        <TableCell align="right">{ticketCity.cityId}</TableCell>
                        <TableCell align="right">{ticketCity.stayingStatus}</TableCell>
                        <TableCell align="right">
                        <Button variant="outlined" onClick={() => deleteTicketCity(ticketCity.airlineTicketId, ticketCity.cityId)} startIcon={<DeleteIcon />}>Delete</Button>
                        </TableCell>
                        </TableRow>
                    ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    );
};

export default PagesTicketCityTable;