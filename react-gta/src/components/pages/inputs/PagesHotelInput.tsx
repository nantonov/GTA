import React, { useState } from 'react';
import PagesTypography from '../PagesTypography';
import { ICreateUpdateHotelModel } from '../../../modelInterfaces/createUpdateInterfaces/ICreateUpdateHotelModel';
import { TextField, Button } from '@mui/material';
import { postHotel, updateHotel } from '../../../redux/thunk/hotelThunk';
import { useDispatch } from 'react-redux';

const PagesHotelInput = ({ creatingInput, id }: { creatingInput: boolean; id: number }) => {
  const [hotel, setHotel] = useState({
    id: id,
    name: '',
    starsNumber: '',
    roomsNumber: '',
    cityId: '',
  });
  const dispatch = useDispatch();

  const create = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const hotelToCreate: ICreateUpdateHotelModel = {
      name: hotel.name,
      starsNumber: Number(hotel.starsNumber),
      roomsNumber: Number(hotel.roomsNumber),
      cityId: Number(hotel.cityId),
    };

    dispatch(postHotel(hotelToCreate));
    setHotel({ id: 0, name: '', starsNumber: '', roomsNumber: '', cityId: '' });
  };

  const update = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const hotelToUpdate: ICreateUpdateHotelModel = {
      name: hotel.name,
      starsNumber: Number(hotel.starsNumber),
      roomsNumber: Number(hotel.roomsNumber),
      cityId: Number(hotel.cityId),
    };

    dispatch(updateHotel(id, hotelToUpdate));
    setHotel({ id: 0, name: '', starsNumber: '', roomsNumber: '', cityId: '' });
  };

  return (
    <div>
      <form onSubmit={create}>
        <div>
          <PagesTypography>{creatingInput ? 'Create a new' : 'Update'} hotel</PagesTypography>
          <div>
            <TextField
              name="name"
              value={hotel.name}
              id="outlined-basic"
              label="Name"
              variant="outlined"
              onChange={(e) => setHotel({ ...hotel, name: e.target.value })}
            />

            <TextField
              name="startNumber"
              value={hotel.starsNumber}
              type="number"
              id="outlined-basic"
              label="StartNumber"
              variant="outlined"
              onChange={(e) => setHotel({ ...hotel, starsNumber: e.target.value })}
            />

            <TextField
              name="roomsNumber"
              value={hotel.roomsNumber}
              type="number"
              id="outlined-basic"
              label="RoomsNumber"
              variant="outlined"
              onChange={(e) => setHotel({ ...hotel, roomsNumber: e.target.value })}
            />

            <TextField
              name="cityId"
              value={hotel.cityId}
              type="number"
              id="outlined-basic"
              label="City ID"
              variant="outlined"
              onChange={(e) => setHotel({ ...hotel, cityId: e.target.value })}
            />
          </div>
          <div style={{ margin: '10px 280px' }}>
            <Button type="submit" onClick={creatingInput ? create : update} variant="contained">
              {creatingInput ? 'Create' : 'Update'}
            </Button>
          </div>
        </div>
      </form>
    </div>
  );
};

export default PagesHotelInput;
