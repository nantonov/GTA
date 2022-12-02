import React, { useContext, useEffect } from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import Typography from '@mui/material/Typography';
import AppNavLink from '../appNavLink/AppNavLink';
import { Button } from '@mui/material';
import UserService from '../../services/UserService';
import LoginIcon from '@mui/icons-material/Login';
import LogoutIcon from '@mui/icons-material/Logout';
import { RootState } from '../../redux/reducers/rootReducer';
import { useSelector } from 'react-redux';
import { useDispatch } from 'react-redux';
import { AuthActionTypes } from '../../redux/actionTypes/authTypes';

const AppNavBar = () => {
  const dispatch = useDispatch();

  useEffect(() => {
    const getUser = async () => {
      const user = await UserService.getUser();
      user && dispatch({ type: AuthActionTypes.SetIsAuth, payload: true });
      !user && (await UserService.signIn());
    };

    setTimeout(() => getUser(), 250);
  }, [dispatch]);

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <IconButton size="large" edge="start" color="inherit" aria-label="menu" sx={{ mr: 2 }}>
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Gleb Tickets App
          </Typography>
          <AppNavLink path="/tickets" content="Tickets" />
          <AppNavLink path="/cities" content="Cities" />
          <AppNavLink path="/hotels" content="Hotels" />
          <AppNavLink path="/ticketCities" content="TicketCities" />
          <Button
            onClick={async () => await UserService.signOut()}
            color="inherit"
            startIcon={<LogoutIcon />}
          >
            <Typography color="cyan" variant="subtitle1" component="div" sx={{ flexGrow: 1 }}>
              Logout
            </Typography>
          </Button>
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export default AppNavBar;
