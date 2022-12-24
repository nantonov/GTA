import { combineReducers } from '@reduxjs/toolkit';
import ModalReducer from './modalReducer';
import AuthReducer from './authReducer';
import cityReducer from './cityReducer';
import ticketReducer from './ticketReducer';
import hotelReducer from './hotelReducer';
import ticketCityReducer from './ticketCityReducer';
import notificationsReducer from './notificationsReducer';
import historyReducer from './historyReducer';

const rootReducer = combineReducers({
  modal: ModalReducer,
  auth: AuthReducer,
  city: cityReducer,
  ticket: ticketReducer,
  hotel: hotelReducer,
  ticketCity: ticketCityReducer,
  notifications: notificationsReducer,
  history: historyReducer,
});

export type RootState = ReturnType<typeof rootReducer>;
export default rootReducer;
