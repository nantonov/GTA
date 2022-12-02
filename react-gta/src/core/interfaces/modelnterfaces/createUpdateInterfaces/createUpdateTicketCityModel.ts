import { cityStayingStatus } from '../../../enums/CityStayingStatus';

export interface CreateUpdateTicketCityModel {
  stayingStatus: cityStayingStatus;

  airlineTicketId: number;
  cityId: number;
}
