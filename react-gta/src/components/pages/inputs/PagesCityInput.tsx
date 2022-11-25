import React, { useState } from "react";
import PagesTypography from "../PagesTypography";
import { ICreateUpdateCityModel } from "../../../modelInterfaces/createUpdateInterfaces/ICreateUpdateCityModel";
import { TextField, Button } from "@mui/material";
import CityService from "../../../services/CityService";

const PagesCityInput = ({
  creatingInput,
  id,
}: {
  creatingInput: boolean;
  id: number;
}) => {
  const [city, setCity] = useState({
    id: id,
    name: "",
    population: "",
    area: "",
  });

  const addNewCity = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const cityToCreate: ICreateUpdateCityModel = {
      name: city.name,
      population: Number(city.population),
      area: Number(city.area),
    };

    CityService.create(cityToCreate);
    setCity({ id: 0, name: "", population: "", area: "" });
  };

  const updateCity = (e: React.SyntheticEvent) => {
    e.preventDefault();
    const cityToUpdate: ICreateUpdateCityModel = {
      name: city.name,
      population: Number(city.population),
      area: Number(city.area),
    };

    CityService.update(id, cityToUpdate);
    setCity({ id: 0, name: "", population: "", area: "" });
  };

  return (
    <div>
      <form onSubmit={addNewCity}>
        <div>
          <PagesTypography>
            {creatingInput ? "Create a new" : "Update"} city
          </PagesTypography>
          <div>
            <TextField
              name="name"
              value={city.name}
              id="outlined-basic"
              label="Name"
              variant="outlined"
              onChange={(e) => setCity({ ...city, name: e.target.value })}
            />

            <TextField
              name="population"
              value={city.population}
              type="number"
              id="outlined-basic"
              label="Population"
              variant="outlined"
              onChange={(e) =>
                setCity({ ...city, population: String(e.target.value) })
              }
            />

            <TextField
              name="area"
              value={city.area}
              type="number"
              id="outlined-basic"
              label="Area"
              variant="outlined"
              onChange={(e) =>
                setCity({ ...city, area: String(e.target.value) })
              }
            />
          </div>
          <div style={{ margin: "10px 280px" }}>
            <Button
              type="submit"
              onClick={creatingInput ? addNewCity : updateCity}
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

export default PagesCityInput;
