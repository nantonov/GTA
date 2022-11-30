import React, { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { getAllCities } from '../../redux/thunk/cityThunk';
import City from '../../../pages/Cities/City';
import Hotel from '../../../pages/Hotels/Hotel';
import Ticket from '../../../pages/Tickets/Ticket';
import TicketCity from '../../../pages/TicketCities/TicketCity';
import Tickets from '../../../pages/Tickets/Tickets';
import { routes } from '../../constants/routes';
import { RootState } from '../../redux/reducers/rootReducer';
import AppNavBar from '../appNavBar/AppNavBar';

const AppRouter = () => {
  const dispatch = useDispatch();
  dispatch(getAllCities());
  const cities = useSelector((state: RootState) => state.city.cities);
  const tickets = useSelector((state: RootState) => state.ticket.tickets);
  const ticketCities = useSelector((state: RootState) => state.ticketCity.ticketCities);
  const hotels = useSelector((state: RootState) => state.hotel.hotels);

  return (
    <Router>
      <AppNavBar />
      <Routes>
        <Route index element={<Tickets />} />
        {routes.map((route) => (
          <Route path={route.path} element={<route.component />} key={route.path}></Route>
        ))}
        <Route path="/city/:cityId" element={<City cities={cities} />}></Route>
        <Route path="/ticket/:ticketId" element={<Ticket tickets={tickets} />}></Route>
        <Route
          path="/ticketCity/ticket/:urlTicketId/city/:urlCityId"
          element={<TicketCity ticketCities={ticketCities} />}
        ></Route>
        <Route path="/hotel/:hotelId" element={<Hotel hotels={hotels} />}></Route>
        <Route path="*" element={<Tickets />} />
      </Routes>
    </Router>
  );
};

export default AppRouter;
