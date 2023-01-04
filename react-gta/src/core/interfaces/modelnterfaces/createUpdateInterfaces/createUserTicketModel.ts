export interface CreateUserTicketModel {
  userId: string;
  ticketId: number;
  departureTime: Date;
  arrivalTime: Date;
  price: number;
  passengerCredentials: string;
}
