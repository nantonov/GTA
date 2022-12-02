import { CityGetModel } from './cityGetModel';
import { TicketGetModel } from './ticketGetModel';

export default interface TicketCityGetModel {
  stayingStatus: number;

  airlineTicketId: number;
  ticket: TicketGetModel;
  cityId: number;
  city: CityGetModel;
}
