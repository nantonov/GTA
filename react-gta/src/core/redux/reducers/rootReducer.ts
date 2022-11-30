import { combineReducers } from '@reduxjs/toolkit';
import ModalReducer from './modalReducer';
import AuthReducer from './authReducer';
import cityReducer from './cityReducer';
import ticketReducer from './ticketReducer';
import hotelReducer from './hotelReducer';
import ticketCityReducer from './ticketCityReducer';

const rootReducer = combineReducers({
  modal: ModalReducer,
  auth: AuthReducer,
  city: cityReducer,
  ticket: ticketReducer,
  hotel: hotelReducer,
  ticketCity: ticketCityReducer,
});

export type RootState = ReturnType<typeof rootReducer>;
export default rootReducer;
