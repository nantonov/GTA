using AirlineTicketsNotifications.BLL.Models.Requests;
using AirlineTicketsNotifications.DAL.Entities;
using AutoMapper;

namespace AirlineTicketsNotifications.BLL.Mapper.Profiles
{
    public class EntityModel : Profile
    {
        public EntityModel()
        {
            CreateMap<NotificationRequestEntity, NotificationRequest>().ReverseMap();
        }
    }
}
