import React from 'react';
import { NavLink } from 'react-router-dom';
import Typography from '@mui/material/Typography';
import styled from 'styled-components';

const NavLinkTemplate = (props: { path: string; content: string; className?: any }) => {
  return (
    <NavLink className={props.className} to={props.path}>
      <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
        {props.content}
      </Typography>
    </NavLink>
  );
};

const AppNavLink = styled(NavLinkTemplate)`
  text-decoration: none;
  color: cyan;
  margin-left: 15px;
  margin-right: 15px;
`;

export default AppNavLink;
