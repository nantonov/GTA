import { CityGetModel } from './cityGetModel';

export default interface HotelGetModel {
  id: number;
  name: string;
  starsNumber: number;
  roomsNumber: number;

  city: CityGetModel;
}
