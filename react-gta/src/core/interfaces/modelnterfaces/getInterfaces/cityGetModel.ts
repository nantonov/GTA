import HotelGetModel from './hotelGetModel';
import TicketCityGetModel from './ticketCityGetModel';

export interface CityGetModel {
  id: number;
  name: string;
  population: number;
  area: number;

  ticketCities: Array<TicketCityGetModel>;
  hotels: Array<HotelGetModel>;
}
