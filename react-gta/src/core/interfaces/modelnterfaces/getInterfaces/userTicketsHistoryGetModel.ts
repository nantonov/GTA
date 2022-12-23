import { TicketGetModel } from './ticketGetModel';

export interface UserTicketsHistoryGetModel {
  userId: string;
  tickets: Array<TicketGetModel>;
}
