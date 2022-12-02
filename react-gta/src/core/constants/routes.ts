import Callback from '../../pages/Auth/Callback';
import Cities from '../../pages/Cities/Cities';
import Hotels from '../../pages/Hotels/Hotels';
import Logout from '../../pages/Auth/Logout';
import Refresh from '../../pages/Auth/Refresh';
import TicketCities from '../../pages/TicketCities/TicketCities';
import Tickets from '../../pages/Tickets/Tickets';

export const routes = [
  { path: '/tickets', component: Tickets, exact: true },
  { path: '/cities', component: Cities, exact: true },
  { path: '/hotels', component: Hotels, exact: true },
  { path: '/ticketCities', component: TicketCities, exact: true },
  { path: '/callback', component: Callback, exact: true },
  { path: '/logout', component: Logout, exact: true },
  { path: '/refresh', component: Refresh, exact: true },
];
