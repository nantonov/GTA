using AirlineTicketsHistory.API.ViewModels.AirlineTicket;
using AirlineTicketsHistory.API.ViewModels.TicketsHistory;
using AirlineTicketsHistory.BLL.Models;
using AutoMapper;

namespace AirlineTicketsHistory.API.Mapper.Profiles
{
    public class ModelViewModel : Profile
    {
        public ModelViewModel()
        {
            CreateMap<AirlineTicket, AirlineTicketViewModel>();
            CreateMap<CreateAirlineTicketViewModel, AirlineTicket>();
            CreateMap<UserTicketsHistory, UserTicketsHistoryViewModel>();
        }
    }
}
