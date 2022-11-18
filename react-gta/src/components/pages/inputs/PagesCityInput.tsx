import React, { useState } from 'react';
import PagesTypography from '../PagesTypography';
import { ICreateUpdateCityModel } from '../../../modelInterfaces/createUpdateInterfaces/ICreateUpdateCityModel';
import { TextField, Button } from '@mui/material';
import CityService from '../../../services/CityService';


const PagesCityInput = () => {

    const [city, setCity] = useState({name: "", population: "", area: ""})

    const addNewCity = (e: React.SyntheticEvent) => {
        e.preventDefault();
        const cityToCreate : ICreateUpdateCityModel = {
            name: city.name,
            population: Number(city.population),
            area: Number(city.area)
        }
        CityService.create(cityToCreate)
        setCity({name: "", population: "", area: ""})
    }

    return (
        <div>
            <form onSubmit={addNewCity}>
                <div>
                    <PagesTypography>Create a new city</PagesTypography>
                    <div>
                        <TextField 
                        name="name"
                        value={city.name} 
                        id="outlined-basic" 
                        label="Name" 
                        variant="outlined" 
                        onChange={e => setCity({...city, name: e.target.value})}
                        />

                        <TextField 
                        name="population"
                        value={city.population} 
                        type="number" 
                        id="outlined-basic" 
                        label="Population" 
                        variant="outlined" 
                        onChange={e => setCity({...city, population: e.target.value})}
                        />

                        <TextField 
                        name="area"
                        value={city.area} 
                        type="number" 
                        id="outlined-basic" 
                        label="Area" 
                        variant="outlined" 
                        onChange={e => setCity({...city, area: e.target.value})}
                        />
                    </div>
                    <div style={{margin:"10px 280px"}}>
                        <Button type="submit" onClick={addNewCity} variant="contained">Create</Button>
                    </div>
                </div>
            </form>
        </div>
    );
};

export default PagesCityInput;