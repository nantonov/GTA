using AirlineTickets.BLL.Models;
using AutoMapper;
using Messages;

namespace AirlineTickets.BLL.Mapper.Profiles
{
    internal class MessageModel : Profile
    {
        public MessageModel()
        {
            CreateMap<Message, NewTicketInfoMessage>().ReverseMap();
        }
    }
}
