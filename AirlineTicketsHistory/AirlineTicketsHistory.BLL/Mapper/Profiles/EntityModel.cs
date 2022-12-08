using AirlineTicketsHistory.BLL.Models;
using AirlineTicketsHistory.DAL.Entities;
using AutoMapper;

namespace AirlineTicketsHistory.BLL.Mapper.Profiles
{
    public class EntityModel : Profile
    {
        public EntityModel()
        {
            CreateMap<AirlineTicketEntity, AirlineTicket>().ReverseMap();
            CreateMap<UserTicketsHistoryEntity, UserTicketsHistory>().ReverseMap();
        }
    }
}
