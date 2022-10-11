using AirlineTickets.API.ViewModels.AirlineTicket;
using AirlineTickets.API.ViewModels.AirlineTicketCity;
using AirlineTickets.API.ViewModels.City;
using AirlineTickets.API.ViewModels.Hotel;
using AirlineTickets.Business.Models;
using AutoMapper;

namespace AirlineTickets.API.Mapper.Profiles
{
    public class ModelViewModel : Profile
    {
        public ModelViewModel()
        {
            CreateMap<AirlineTicket, TicketViewModel>().ReverseMap();
            CreateMap<AirlineTicket, CreateUpdateTicketViewModel>().ReverseMap();
            CreateMap<AirlineTicketCity, TicketCityViewModel>().ReverseMap();
            CreateMap<AirlineTicketCity, CreateUpdateTicketCityViewModel>().ReverseMap();
            CreateMap<City, CityViewModel>().ReverseMap();
            CreateMap<City, CreateUpdateCityViewModel>().ReverseMap();
            CreateMap<Hotel, HotelViewModel>().ReverseMap();
            CreateMap<Hotel, CreateUpdateHotelViewModel>().ReverseMap();
        }
    }
}
