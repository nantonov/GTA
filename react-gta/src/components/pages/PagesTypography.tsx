import React from 'react';
import { Typography } from '@mui/material';

const PagesTypography = (props: any) => {
  return (
    <div>
      <Typography
        marginLeft="200px"
        marginBottom="10px"
        marginTop="10px"
        color="rgb(0, 0, 139)"
        variant="h4"
        component="div"
        sx={{ flexGrow: 1 }}
      >
        {props.children}
      </Typography>
    </div>
  );
};

export default PagesTypography;
