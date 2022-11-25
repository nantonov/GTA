import { TextField, Button } from "@mui/material";
import React, { useState } from "react";
import PagesTypography from "../PagesTypography";
import { ICreateUpdateTicketCityModel } from "../../../modelInterfaces/createUpdateInterfaces/ICreateUpdateTicketCityModel";
import TicketCityService from "../../../services/TicketCityService";
import MenuItem from "@mui/material/MenuItem";
import Select from "@mui/material/Select";

const PagesTicketCityInput = ({ creatingInput, ticketId, cityId, }: { creatingInput: boolean; ticketId: number; cityId: number; }) => {
  
  const [ticketCity, setTicketCity] = useState({
    status: 0,
    airlineTicketId: String(ticketId),
    cityId: String(cityId),
  });

  const addNewTicketCity = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const ticketCityToCreate: ICreateUpdateTicketCityModel = {
      stayingStatus: Number(ticketCity.status),
      airlineTicketId: Number(ticketCity.airlineTicketId),
      cityId: Number(ticketCity.cityId),
    };
    TicketCityService.create(ticketCityToCreate);
    setTicketCity({ status: 0, airlineTicketId: "", cityId: "" });
  };

  const updateTicketCity = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const ticketCityToUpdate: ICreateUpdateTicketCityModel = {
      stayingStatus: Number(ticketCity.status),
      airlineTicketId: Number(ticketCity.airlineTicketId),
      cityId: Number(ticketCity.cityId),
    };

    TicketCityService.update(ticketCityToUpdate);
    setTicketCity({ status: 0, airlineTicketId: "", cityId: "" });
  };

  return (
    <div>
      <form onSubmit={addNewTicketCity}>
        <div>
          <PagesTypography>
            {creatingInput ? "Create a new" : "Update"} ticket-city
          </PagesTypography>
          <div>
            <Select
              labelId="demo-simple-select-label"
              id="demo-simple-select"
              value={ticketCity.status}
              label="Staying status"
              onChange={(e) =>
                setTicketCity({ ...ticketCity, status: Number(e.target.value) })
              }
            >
              <MenuItem value={0}>Departure</MenuItem>
              <MenuItem value={1}>Arrival</MenuItem>
              <MenuItem value={2}>Transit</MenuItem>
            </Select>

            <TextField
              name="airlineTicketId"
              value={ticketCity.airlineTicketId}
              type="number"
              id="outlined-basic"
              label="Airline Ticket ID"
              variant="outlined"
              onChange={(e) =>
                setTicketCity({
                  ...ticketCity,
                  airlineTicketId: e.target.value,
                })
              }
            />

            <TextField
              name="cityId"
              value={ticketCity.cityId}
              type="number"
              id="outlined-basic"
              label="City ID"
              variant="outlined"
              onChange={(e) =>
                setTicketCity({
                  ...ticketCity,
                  cityId: e.target.value,
                })
              }
            />
          </div>
          <div style={{ margin: "10px 280px" }}>
            <Button
              type="submit"
              onClick={creatingInput ? addNewTicketCity : updateTicketCity}
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

export default PagesTicketCityInput;