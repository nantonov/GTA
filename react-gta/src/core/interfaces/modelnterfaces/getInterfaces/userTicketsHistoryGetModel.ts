import { HistoryTicketGetModel } from './historyTicketGetModel';

export interface UserTicketsHistoryGetModel {
  userId: string;
  airlineTickets: Array<HistoryTicketGetModel>;
}
