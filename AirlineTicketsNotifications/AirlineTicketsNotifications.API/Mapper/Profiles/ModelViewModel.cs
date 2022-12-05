using AirlineTicketsNotifications.API.ViewModels.NotificationRequest;
using AirlineTicketsNotifications.API.ViewModels.TicketInfo;
using AirlineTicketsNotifications.BLL.Models.Requests;
using AirlineTicketsNotifications.BLL.Models.TicketInfo;
using AutoMapper;

namespace AirlineTicketsNotifications.API.Mapper.Profiles
{
    public class ModelViewModel : Profile
    {
        public ModelViewModel()
        {
            CreateMap<NewTicketInfoViewModel, NewTicketInfo>().ReverseMap();
            CreateMap<CreateNotificationRequestViewModel, NotificationRequest>();
            CreateMap<NotificationRequest, NotificationRequestViewModel>();
        }
    }
}
