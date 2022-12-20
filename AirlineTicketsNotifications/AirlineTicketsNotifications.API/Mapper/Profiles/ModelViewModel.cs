using AirlineTicketsNotifications.API.Messages;
using AirlineTicketsNotifications.API.ViewModels.NotificationRequest;
using AirlineTicketsNotifications.BLL.Models.Requests;
using AirlineTicketsNotifications.BLL.Models.TicketInfo;
using AutoMapper;

namespace AirlineTicketsNotifications.API.Mapper.Profiles
{
    public class ModelViewModel : Profile
    {
        public ModelViewModel()
        {
            CreateMap<NewTicketInfoMessage, NewTicketInfo>().ReverseMap();
            CreateMap<CreateNotificationRequestViewModel, NotificationRequest>();
            CreateMap<NotificationRequest, NotificationRequestViewModel>();
        }
    }
}
