namespace AirlineTickets.BLL.Models
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }

        public ICollection<AirlineTicketCity>? AirlineTicketCities { get; set; }
        public ICollection<Hotel>? Hotels { get; set; }
    }
}
