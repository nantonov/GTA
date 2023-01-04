import { Button, MenuItem, Select, TextField } from '@mui/material';
import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import styled from 'styled-components';
import { CreateNotificationRequestModel } from '../../interfaces/modelnterfaces/createUpdateInterfaces/createNotificationRequestModel';
import { createNotificationRequest } from '../../redux/thunk/notificationsThunk';
import PagesTypography from '../appTypography/AppTypography';

const PagesNotificationsInputTemplate = (props: { className?: any }) => {
  const [request, setRequest] = useState({
    email: '',
    stayingStatus: 0,
    cityName: '',
  });
  const dispatch = useDispatch();

  const create = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const requestToCreate: CreateNotificationRequestModel = {
      email: request.email,
      stayingStatus: Number(request.stayingStatus),
      cityName: request.cityName,
    };

    dispatch(createNotificationRequest(requestToCreate));
    setRequest({ email: '', stayingStatus: 0, cityName: '' });
  };

  return (
    <div className={props.className}>
      <form>
        <PagesTypography>Create a notification request</PagesTypography>
        <div>
          <TextField
            name="cityName"
            value={request.cityName}
            id="outlined-basic"
            label="City"
            variant="outlined"
            onChange={(e) =>
              setRequest({
                ...request,
                cityName: e.target.value,
              })
            }
          />

          <Select
            labelId="demo-simple-select-label"
            id="demo-simple-select"
            value={request.stayingStatus}
            label="Staying status"
            onChange={(e) => setRequest({ ...request, stayingStatus: Number(e.target.value) })}
          >
            <MenuItem value={0}>Departure</MenuItem>
            <MenuItem value={1}>Arrival</MenuItem>
            <MenuItem value={2}>Transit</MenuItem>
          </Select>

          <TextField
            name="email"
            value={request.email}
            id="outlined-basic"
            label="Email"
            variant="outlined"
            onChange={(e) =>
              setRequest({
                ...request,
                email: e.target.value,
              })
            }
          />
        </div>
        <div style={{ margin: '10px' }}>
          <Button type="submit" onClick={create} variant="contained">
            {'Create a request'}
          </Button>
        </div>
      </form>
    </div>
  );
};

const PagesNotificationsInput = styled(PagesNotificationsInputTemplate)`
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  border: 2px solid #6cd7b1;
  display: flex;
  justify-content: center;
  align-items: center;
  text-align: center;
  vertical-align: middle;
`;

export default PagesNotificationsInput;
