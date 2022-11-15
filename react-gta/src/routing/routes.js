import Cities from "./pages/Cities";
import Hotels from "./pages/Hotels";
import Login from "./pages/Login";
import Logout from "./pages/Logout";
import Registration from "./pages/Registration";
import TicketCities from "./pages/TicketCities";
import Tickets from "./pages/Tickets";

export const routes = [
    {path: "/tickets", component: <Tickets/>, exact: true},
    {path: "/cities", component: <Cities/>, exact: true},
    {path: "/hotels", component: <Hotels/>, exact: true},
    {path: "/ticketCities", component: <TicketCities/>, exact: true},
    {path: "/login", component: <Login/>, exact: true},
    {path: "/logout", component: <Logout/>, exact: true},
    {path: "/registration", component: <Registration/>, exact: true},
]