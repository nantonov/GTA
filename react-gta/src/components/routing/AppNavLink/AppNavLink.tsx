import React from 'react';
import { NavLink } from 'react-router-dom';
import Typography from '@mui/material/Typography';
import './AppNavLink.css'

const AppNavLink = (props: { path: string; content: string }) => {
    return (
        <NavLink className="navlink" to={props.path}>
            <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
                {props.content}
            </Typography>
        </NavLink>
    );
};

export default AppNavLink;