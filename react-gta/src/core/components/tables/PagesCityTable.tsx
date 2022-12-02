import React, { useEffect, useState } from 'react';
import { Button } from '@mui/material';
import DeleteIcon from '@mui/icons-material/Delete';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import EditIcon from '@mui/icons-material/Edit';
import PagesCityInput from '../inputs/PagesCityInput';
import AppModalWrapper from '../appModalWrapper/AppModalWrapper';
import { useSelector } from 'react-redux';
import { ModalActionTypes } from '../../redux/actionTypes/modalTypes';
import { RootState } from '../../redux/reducers/rootReducer';
import { useDispatch } from 'react-redux';
import PagesTypography from '../appTypography/AppTypography';
import { deleteCity, getAllCities } from '../../redux/thunk/cityThunk';
import { Link } from 'react-router-dom';

const PagesCityTable = () => {
  const [updateCityId, setUpdateCityId] = useState(0);
  const [deleteCityId, setDeleteCityId] = useState(0);

  const openModal = useSelector((state: RootState) => state.modal);
  const cities = useSelector((state: RootState) => state.city.cities);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(getAllCities());
  });

  const openEditingCityModalWindow = (updateCityId: number) => {
    setUpdateCityId(updateCityId);
    dispatch({ type: ModalActionTypes.ShowUpdateModal });
  };

  const openDeletingCityModalWindow = (deleteCityId: number) => {
    setDeleteCityId(deleteCityId);
    dispatch({ type: ModalActionTypes.ShowDeleteModal });
  };

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
              <TableRow key={city.id} sx={{ '&:last-child td, &:last-child th': { border: 0 } }}>
                <TableCell component="th" scope="row">
                  <Link to={`/city/${city.id}`}>{city.id}</Link>
                </TableCell>
                <TableCell align="right">{city.name}</TableCell>
                <TableCell align="right">{city.population}</TableCell>
                <TableCell align="right">{city.area}</TableCell>
                <TableCell align="right">
                  <Button
                    variant="outlined"
                    onClick={() => openDeletingCityModalWindow(city.id)}
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
      <AppModalWrapper
        open={openModal.updateModal}
        onClose={() => {
          dispatch({ type: ModalActionTypes.HideUpdateModal });
        }}
      >
        <PagesCityInput creatingInput={false} id={updateCityId} />
      </AppModalWrapper>
      <AppModalWrapper
        open={openModal.deleteModal}
        onClose={() => {
          dispatch({ type: ModalActionTypes.HideDeleteModal });
        }}
      >
        <PagesTypography align="center">
          <div>Delete the city?</div>
          <Button
            variant="outlined"
            onClick={async () => {
              dispatch(deleteCity(deleteCityId));
              dispatch({ type: ModalActionTypes.HideDeleteModal });
            }}
          >
            Yes
          </Button>
          <Button
            variant="outlined"
            onClick={() => dispatch({ type: ModalActionTypes.HideDeleteModal })}
          >
            No
          </Button>
        </PagesTypography>
      </AppModalWrapper>
    </div>
  );
};

export default PagesCityTable;
