using AirlineTickets.Business.Models;
using AirlineTickets.Data.Entities;
using AutoMapper;

namespace AirlineTickets.API.Mapper.Profiles
{
    public class EntityModel : Profile
    {
        public EntityModel()
        {
            CreateMap<AirlineTicketEntity, AirlineTicket>().ReverseMap();
            CreateMap<AirlineTicketCityEntity, AirlineTicketCity>().ReverseMap();
            CreateMap<CityEntity, City>().ReverseMap();
            CreateMap<HotelEntity, Hotel>().ReverseMap();
        }
    }
}
