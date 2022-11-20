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
import HotelService from "../../../services/HotelService";
import IHotelGetModel from "../../../modelInterfaces/getInterfaces/IHotelGetModel";
import EditIcon from "@mui/icons-material/Edit";
import Modal from "@mui/material/Modal";
import Box from "@mui/material/Box";
import PagesHotelInput from "../inputs/PagesHotelInput";
import "./Tables.css";

const PagesHotelTable = () => {
  
  const [hotels, setHotels] = useState(new Array<IHotelGetModel>());
  const [open, setOpen] = useState(false);
  const [updateHotelId, setUpdateHotelId] = useState(0);

  const getHotels = async () => {
    const response = await HotelService.getAll();
    setHotels(response);
  };

  getHotels();

  const openEditingCityModalWindow = async (updateHotelId: number) => {
    setOpen(true);
    setUpdateHotelId(updateHotelId);
  };

  return (
    <div>
      <TableContainer component={Paper}>
        <Table sx={{ minWidth: 650 }} aria-label="simple table">
          <TableHead>
            <TableRow>
              <TableCell width={100}>Id</TableCell>
              <TableCell align="right">Name</TableCell>
              <TableCell align="right">Stars number</TableCell>
              <TableCell align="right">Rooms number</TableCell>
              <TableCell align="right">City ID</TableCell>
              <TableCell align="right"></TableCell>
              <TableCell align="right"></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {hotels.map((hotel) => (
              <TableRow
                key={hotel.id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {hotel.id}
                </TableCell>
                <TableCell align="right">{hotel.name}</TableCell>
                <TableCell align="right">{hotel.starsNumber}</TableCell>
                <TableCell align="right">{hotel.roomsNumber}</TableCell>
                <TableCell align="right">{hotel.city.id}</TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={async () => await HotelService.delete(hotel.id)}
                    startIcon={<DeleteIcon />}
                  >
                    Delete
                  </Button>
                </TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={() => openEditingCityModalWindow(hotel.id)}
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
          <PagesHotelInput creatingInput={false} id={updateHotelId} />
        </Box>
      </Modal>
    </div>
  );
};

export default PagesHotelTable;
