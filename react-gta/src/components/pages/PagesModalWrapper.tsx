import React from 'react';
import Modal from '@mui/material/Modal';
import Box from '@mui/material/Box';
import styled from 'styled-components';

const ModalWrapperTemplate = (props: {
  open: boolean;
  onClose: (value: React.SetStateAction<boolean>) => void;
  children: React.ReactNode;
  className?: any;
}) => {
  return (
    <div>
      <Modal
        open={props.open}
        onClose={props.onClose}
        aria-labelledby="parent-modal-title"
        aria-describedby="parent-modal-description"
      >
        <Box className={props.className} sx={{ width: 400 }}>
          {props.children}
        </Box>
      </Modal>
    </div>
  );
};

const PagesModalWrapper = styled(ModalWrapperTemplate)`
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  border: 2px solid #000;
  background-color: white;
  box-shadow: 24;
  padding-top: 2;
  padding-left: 4;
  padding-right: 4;
  padding-bottom: 3;
  text-align: center;
`;

export default PagesModalWrapper;
