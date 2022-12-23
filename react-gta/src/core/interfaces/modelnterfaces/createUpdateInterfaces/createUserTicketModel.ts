export interface CreateUserTicketModel {
  userId: string;
  ticketId: number;
  departureTime: string;
  arrivalTime: string;
  price: number;
  passengerCredentials: string;
}
