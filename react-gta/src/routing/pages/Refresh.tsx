import React from 'react';
import { Navigate } from 'react-router-dom';
import UserService from '../../services/UserService';

const Refresh: React.FC = () => {
  UserService.signInSilentCallback();
  return (
    <div>
      <Navigate to="/" replace={true} />
    </div>
  );
};

export default Refresh;
