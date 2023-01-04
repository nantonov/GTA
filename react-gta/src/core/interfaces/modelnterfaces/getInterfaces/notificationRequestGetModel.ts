import { cityStayingStatus } from '../../../enums/CityStayingStatus';

export interface NotificationRequestGetModel {
  id: number;
  email: string;
  stayingStatus: cityStayingStatus;
  cityName: string;
}
