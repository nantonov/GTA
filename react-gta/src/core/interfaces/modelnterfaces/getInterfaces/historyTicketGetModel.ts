export interface HistoryTicketGetModel {
  ticketId: number;
  departureTime: Date;
  arrivalTime: Date;
  price: number;
  passengerCredentials: string;
}
