import React, { useContext } from "react";
import { AuthContext } from "../authorization/AuthProvider";
import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import IconButton from "@mui/material/IconButton";
import MenuIcon from "@mui/icons-material/Menu";
import Typography from "@mui/material/Typography";
import AppNavLink from "./AppNavLink/AppNavLink";
import { Button } from "@mui/material";
import UserService from "../../services/UserService";
import LoginIcon from "@mui/icons-material/Login";
import LogoutIcon from "@mui/icons-material/Logout";

const AppNavBar = () => {
  const context = useContext(AuthContext);

  return (
    <Box sx={{ flexGrow: 1 }}>
      <AppBar position="static">
        <Toolbar>
          <IconButton
            size="large"
            edge="start"
            color="inherit"
            aria-label="menu"
            sx={{ mr: 2 }}
          >
            <MenuIcon />
          </IconButton>
          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            Gleb Tickets App
          </Typography>
          <AppNavLink path="/tickets" content="Tickets" />
          <AppNavLink path="/cities" content="Cities" />
          <AppNavLink path="/hotels" content="Hotels" />
          <AppNavLink path="/ticketCities" content="TicketCities" />
          {!context.isAuth ? (
            <Button
              onClick={async () => await UserService.signIn()}
              color="inherit"
              startIcon={<LoginIcon />}
            >
              <Typography
                color="cyan"
                variant="subtitle1"
                component="div"
                sx={{ flexGrow: 1 }}
              >
                Login
              </Typography>
            </Button>
          ) : (
            <Button
              onClick={async () => await UserService.signOut()}
              color="inherit"
              startIcon={<LogoutIcon />}
            >
              <Typography
                color="cyan"
                variant="subtitle1"
                component="div"
                sx={{ flexGrow: 1 }}
              >
                Logout
              </Typography>
            </Button>
          )}
        </Toolbar>
      </AppBar>
    </Box>
  );
};

export default AppNavBar;
