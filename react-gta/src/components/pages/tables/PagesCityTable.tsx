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
import CityService from "../../../services/CityService";
import { ICityGetModel } from "../../../modelInterfaces/getInterfaces/ICityGetModel";
import EditIcon from "@mui/icons-material/Edit";
import Modal from "@mui/material/Modal";
import Box from "@mui/material/Box";
import PagesCityInput from "../inputs/PagesCityInput";
import "./Tables.css";

const PagesCityTable = () => {
  const [cities, setCities] = useState(new Array<ICityGetModel>());
  const [open, setOpen] = useState(false);
  const [updateCityId, setUpdateCityId] = useState(0);

  const handleClose = () => {
    setOpen(false);
  };

  const getCities = async () => {
    const response = await CityService.getAll();
    setCities(response);
  };

  const deleteCity = async (cityId: number) => {
    await CityService.delete(cityId);
  };

  const openEditingCityModalWindow = async (updateCityId: number) => {
    setOpen(true);
    setUpdateCityId(updateCityId);
  };

  getCities();

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
              <TableCell align="right"></TableCell>
              <TableCell align="right"></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {cities.map((city) => (
              <TableRow
                key={city.id}
                sx={{ "&:last-child td, &:last-child th": { border: 0 } }}
              >
                <TableCell component="th" scope="row">
                  {city.id}
                </TableCell>
                <TableCell align="right">{city.name}</TableCell>
                <TableCell align="right">{city.population}</TableCell>
                <TableCell align="right">{city.area}</TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={() => deleteCity(city.id)}
                    startIcon={<DeleteIcon />}
                  >
                    Delete
                  </Button>
                </TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={() => openEditingCityModalWindow(city.id)}
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
        onClose={() => handleClose()}
        aria-labelledby="parent-modal-title"
        aria-describedby="parent-modal-description"
      >
        <Box className="modal" sx={{ width: 400 }}>
          <PagesCityInput creatingInput={false} id={updateCityId} />
        </Box>
      </Modal>
    </div>
  );
};

export default PagesCityTable;
