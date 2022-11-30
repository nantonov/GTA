import React, { useState } from 'react';
import PagesTypography from '../appTypography/AppTypography';
import { CreateUpdateCityModel } from '../../interfaces/modelnterfaces/createUpdateInterfaces/createUpdateCityModel';
import { TextField, Button } from '@mui/material';
import { useDispatch } from 'react-redux';
import { postCity, updateCity } from '../../redux/thunk/cityThunk';

const PagesCityInput = ({ creatingInput, id }: { creatingInput: boolean; id: number }) => {
  const [city, setCity] = useState({
    id: id,
    name: '',
    population: '',
    area: '',
  });
  const dispatch = useDispatch();

  const create = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const cityToCreate: CreateUpdateCityModel = {
      name: city.name,
      population: Number(city.population),
      area: Number(city.area),
    };

    dispatch(postCity(cityToCreate));
    setCity({ id: 0, name: '', population: '', area: '' });
  };

  const update = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const cityToUpdate: CreateUpdateCityModel = {
      name: city.name,
      population: Number(city.population),
      area: Number(city.area),
    };

    dispatch(updateCity(id, cityToUpdate));
    setCity({ id: 0, name: '', population: '', area: '' });
  };

  return (
    <div>
      <form>
        <div>
          <PagesTypography>{creatingInput ? 'Create a new' : 'Update'} city</PagesTypography>
          <div>
            <TextField
              name="name"
              value={city.name}
              id="outlined-basic"
              label="Name"
              variant="outlined"
              onChange={(e) => setCity({ ...city, name: e.target.value })}
            />

            <TextField
              name="population"
              value={city.population}
              type="number"
              id="outlined-basic"
              label="Population"
              variant="outlined"
              onChange={(e) => setCity({ ...city, population: String(e.target.value) })}
            />

            <TextField
              name="area"
              value={city.area}
              type="number"
              id="outlined-basic"
              label="Area"
              variant="outlined"
              onChange={(e) => setCity({ ...city, area: String(e.target.value) })}
            />
          </div>
          <div style={{ margin: '10px' }}>
            <Button type="submit" onClick={creatingInput ? create : update} variant="contained">
              {creatingInput ? 'Create' : 'Update'}
            </Button>
          </div>
        </div>
      </form>
    </div>
  );
};

export default PagesCityInput;
