namespace AirlineTickets.API.Tests.Constants
{
    internal static class RequestUris
    {
        public static string DefaultTicketCityUri = "/AirlineTicketCity";
        public static string GetDeleteTicketCityUri = "/AirlineTicketCity/Ticket/1/City/1";

        public static string DefaultTicketUri = "/AirlineTicket";
        public static string GetDeleteUpdateTicketUri = "/AirlineTicket/1";

        public static string DefaultCityUri = "/City";
        public static string GetDeleteUpdateCityUri = "/City/1";

        public static string DefaultHotelUri = "/Hotel";
        public static string GetDeleteUpdateHotelUri = "/Hotel/1";
    }
}
