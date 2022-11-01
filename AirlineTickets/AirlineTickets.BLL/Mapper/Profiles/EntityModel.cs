using AirlineTickets.BLL.Models;
using AirlineTickets.DAL.Entities;
using AutoMapper;

namespace AirlineTickets.BLL.Mapper.Profiles
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
