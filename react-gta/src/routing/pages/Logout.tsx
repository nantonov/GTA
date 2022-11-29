import React from 'react';
import { Navigate } from 'react-router-dom';
import UserService from '../../services/UserService';

const Logout: React.FC = () => {
  UserService.signOutCallback();
  return (
    <div>
      <Navigate to="/" replace={true} />
    </div>
  );
};

export default Logout;
