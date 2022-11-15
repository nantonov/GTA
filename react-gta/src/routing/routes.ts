import Cities from "./pages/Cities";
import Hotels from "./pages/Hotels";
import TicketCities from "./pages/TicketCities";
import Tickets from "./pages/Tickets";

export const routes = [
    {path: "/tickets", component: Tickets, exact: true},
    {path: "/cities", component: Cities, exact: true},
    {path: "/hotels", component: Hotels, exact: true},
    {path: "/ticketCities", component: TicketCities, exact: true}
]