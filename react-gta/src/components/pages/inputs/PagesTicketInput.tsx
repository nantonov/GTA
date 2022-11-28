import { TextField, Button } from "@mui/material";
import React, { useState } from "react";
import PagesTypography from "../PagesTypography";
import { ICreateUpdateTicketModel } from "../../../modelInterfaces/createUpdateInterfaces/ICreateUpdateTicketModel";
import TicketService from "../../../services/TicketService";
import { postTicket, updateTicket } from "../../../redux/thunk/ticketThunk";
import { useDispatch } from "react-redux";

const PagesTicketInput = ({
  creatingInput,
  id,
}: {
  creatingInput: boolean;
  id: number;
}) => {
  const [ticket, setTicket] = useState({
    id: id,
    departureTime: "",
    arrivalTime: "",
    price: "",
    passengerCredentials: "",
  });
  const dispatch = useDispatch();

  const create = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const ticketToCreate: ICreateUpdateTicketModel = {
      departureTime: ticket.departureTime,
      arrivalTime: ticket.arrivalTime,
      price: Number(ticket.price),
      passengerCredentials: ticket.passengerCredentials,
    };
    dispatch(postTicket(ticketToCreate));
    setTicket({
      id: 0,
      departureTime: "",
      arrivalTime: "",
      price: "",
      passengerCredentials: "",
    });
  };

  const update = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const ticketToUpdate: ICreateUpdateTicketModel = {
      departureTime: ticket.departureTime,
      arrivalTime: ticket.arrivalTime,
      price: Number(ticket.price),
      passengerCredentials: ticket.passengerCredentials,
    };

    dispatch(updateTicket(id, ticketToUpdate));
    setTicket({
      id: 0,
      departureTime: "",
      arrivalTime: "",
      price: "",
      passengerCredentials: "",
    });
  };

  return (
    <div>
      <form onSubmit={create}>
        <div>
          <PagesTypography>
            {creatingInput ? "Create a new" : "Update"} ticket
          </PagesTypography>
          <div>
            <TextField
              name="departureTime"
              value={ticket.departureTime}
              type="datetime-local"
              id="outlined-basic"
              label="Departure Time"
              variant="outlined"
              onChange={(e) =>
                setTicket({ ...ticket, departureTime: e.target.value })
              }
            />

            <TextField
              name="arrivalTime"
              value={ticket.arrivalTime}
              type="datetime-local"
              id="outlined-basic"
              label="Arrival Time"
              variant="outlined"
              onChange={(e) =>
                setTicket({ ...ticket, arrivalTime: e.target.value })
              }
            />

            <TextField
              name="price"
              value={ticket.price}
              type="number"
              id="outlined-basic"
              label="Price"
              variant="outlined"
              onChange={(e) => setTicket({ ...ticket, price: e.target.value })}
            />

            <TextField
              name="passengerCredentials"
              value={ticket.passengerCredentials}
              id="outlined-basic"
              label="Passenger Credentials"
              variant="outlined"
              onChange={(e) =>
                setTicket({ ...ticket, passengerCredentials: e.target.value })
              }
            />
          </div>
          <div style={{ margin: "10px 280px" }}>
            <Button
              type="submit"
              onClick={creatingInput ? create : update}
              variant="contained"
            >
              {creatingInput ? "Create" : "Update"}
            </Button>
          </div>
        </div>
      </form>
    </div>
  );
};

export default PagesTicketInput;
