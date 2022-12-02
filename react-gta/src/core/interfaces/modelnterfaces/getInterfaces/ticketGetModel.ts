import TicketCityGetModel from './ticketCityGetModel';

export interface TicketGetModel {
  id: number;
  departureTime: Date;
  arrivalTime: Date;
  price: number;
  passengerCredentials: string;

  ticketCities: Array<TicketCityGetModel>;
}
