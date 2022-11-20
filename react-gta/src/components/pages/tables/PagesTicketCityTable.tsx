import React, { useState } from "react";
import { Button } from "@mui/material";
import DeleteIcon from "@mui/icons-material/Delete";
import Table from "@mui/material/Table";
import TableBody from "@mui/material/TableBody";
import TableCell from "@mui/material/TableCell";
import TableContainer from "@mui/material/TableContainer";
import TableHead from "@mui/material/TableHead";
import TableRow from "@mui/material/TableRow";
import Paper from "@mui/material/Paper";
import TicketCityService from "../../../services/TicketCityService";
import ITicketCityGetModel from "../../../modelInterfaces/getInterfaces/ITicketCityGetModel";
import EditIcon from "@mui/icons-material/Edit";
import Modal from "@mui/material/Modal";
import Box from "@mui/material/Box";
import PagesTicketCityInput from "../inputs/PagesTicketCityInput";
import "./Tables.css";

const PagesTicketCityTable = () => {

  const [ticketCities, setTicketCities] = useState(new Array<ITicketCityGetModel>());
  const [open, setOpen] = useState(false);
  const [updateTicketId, setUpdateTicketId] = useState(0);
  const [updateCityId, setUpdateCityId] = useState(0);

  const getTicketCities = async () => {
    const response = await TicketCityService.getAll();
    setTicketCities(response);
  };

  getTicketCities();

  const openEditingTicketCityModalWindow = async (
    updateTicketId: number,
    updateCityId: number
  ) => {
    setOpen(true);
    setUpdateTicketId(updateTicketId);
    setUpdateCityId(updateCityId);
  };

  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell width={100}>Ticket ID</TableCell>
              <TableCell width={100}>City ID</TableCell>
              <TableCell align="right">City Staying Status</TableCell>
              <TableCell align="right"></TableCell>
              <TableCell align="right"></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {ticketCities.map((ticketCity) => (
              <TableRow
                key={ticketCity.airlineTicketId + ticketCity.cityId}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {ticketCity.airlineTicketId}
                </TableCell>
                <TableCell align="right">{ticketCity.cityId}</TableCell>
                <TableCell align="right">{ticketCity.stayingStatus}</TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={async () =>
                      await TicketCityService.delete(
                        ticketCity.airlineTicketId,
                        ticketCity.cityId
                      )
                    }
                    startIcon={<DeleteIcon />}
                  >
                    Delete
                  </Button>
                </TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={() =>
                      openEditingTicketCityModalWindow(
                        ticketCity.airlineTicketId,
                        ticketCity.cityId
                      )
                    }
                    startIcon={<EditIcon />}
                  >
                    Edit
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
      <Modal
        open={open}
        onClose={() => setOpen(false)}
        aria-labelledby="parent-modal-title"
        aria-describedby="parent-modal-description"
      >
        <Box className="modalBox" sx={{ width: 400 }}>
          <PagesTicketCityInput
            creatingInput={false}
            ticketId={updateTicketId}
            cityId={updateCityId}
          />
        </Box>
      </Modal>
    </div>
  );
};

export default PagesTicketCityTable;
