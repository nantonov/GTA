import React from "react";
import Modal from "@mui/material/Modal";
import Box from "@mui/material/Box";

const PagesModalWrapper = (props: {
  open: boolean;
  onClose: (value: React.SetStateAction<boolean>) => void;
  children: React.ReactNode;
}) => {
  return (
    <div>
      <Modal
        open={props.open}
        onClose={props.onClose}
        aria-labelledby="parent-modal-title"
        aria-describedby="parent-modal-description"
      >
        <Box className="modalBox" sx={{ width: 400 }}>
          {props.children}
        </Box>
      </Modal>
    </div>
  );
};

export default PagesModalWrapper;
