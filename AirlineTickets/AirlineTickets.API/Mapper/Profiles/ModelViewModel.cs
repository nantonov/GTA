using AirlineTickets.API.ViewModels.AirlineTicket;
using AirlineTickets.API.ViewModels.AirlineTicketCity;
using AirlineTickets.API.ViewModels.City;
using AirlineTickets.API.ViewModels.Hotel;
using AirlineTickets.BLL.Models;
using AutoMapper;

namespace AirlineTickets.API.Mapper.Profiles
{
    public class ModelViewModel : Profile
    {
        public ModelViewModel()
        {
            CreateMap<AirlineTicket, TicketViewModel>();
            CreateMap<CreateUpdateTicketViewModel, AirlineTicket>();
            CreateMap<AirlineTicketCity, TicketCityViewModel>();
            CreateMap<CreateUpdateTicketCityViewModel, AirlineTicketCity>();
            CreateMap<City, CityViewModel>();
            CreateMap<CreateUpdateCityViewModel, City>();
            CreateMap<Hotel, HotelViewModel>();
            CreateMap<CreateUpdateHotelViewModel, Hotel>();
        }
    }
}
