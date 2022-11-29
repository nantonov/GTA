import { cityStayingStatus } from '../../enums/CityStayingStatus';

export interface ICreateUpdateTicketCityModel {
  stayingStatus: cityStayingStatus;

  airlineTicketId: number;
  cityId: number;
}
