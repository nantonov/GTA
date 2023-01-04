import { cityStayingStatus } from '../../../enums/CityStayingStatus';

export interface CreateNotificationRequestModel {
  email: string;
  stayingStatus: cityStayingStatus;
  cityName: string;
}
