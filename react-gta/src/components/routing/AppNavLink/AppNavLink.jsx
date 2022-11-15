import React from 'react';
import { NavLink } from 'react-router-dom';
import Typography from '@mui/material/Typography';
import classes from './AppNavLink.module.css'

const AppNavLink = (props) => {
    return (
        <NavLink className={classes.navlink} to={props.path}>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                {props.content}
            </Typography>
        </NavLink>
    );
};

export default AppNavLink;