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
import TicketService from '../../../services/TicketService';
import { ITicketGetModel } from '../../../modelInterfaces/getInterfaces/ITicketGetModel';

const PagesTicketTable = () => {

    const [tickets, setTickets] = useState(new Array<ITicketGetModel>())

    const getTickets = async () => {
        const response = await TicketService.getAll()
        setTickets(response)
    }

    const deleteTicket = async (ticketId : number) => {
        await TicketService.delete(ticketId)
    }

    getTickets()

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
                    </TableRow>
                    </TableHead>
                    <TableBody>
                    {
                        tickets.map((ticket) => (
                        <TableRow
                        key={ticket.id}
                        sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
                        >
                        <TableCell component="th" scope="row">
                            {ticket.id}
                        </TableCell>
                        <TableCell align="right">{String(ticket.departureTime)}</TableCell>
                        <TableCell align="right">{String(ticket.arrivalTime)}</TableCell>
                        <TableCell align="right">{ticket.price}</TableCell>
                        <TableCell align="right">{ticket.passengerCredentials}</TableCell>
                        <TableCell align="right">
                            <Button variant="outlined" onClick={() => deleteTicket(ticket.id)} startIcon={<DeleteIcon />}>Delete</Button>
                        </TableCell>
                        </TableRow>
                    ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </div>
    );
};

export default PagesTicketTable;