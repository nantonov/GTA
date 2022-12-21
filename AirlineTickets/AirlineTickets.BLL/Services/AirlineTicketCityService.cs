using AirlineTickets.BLL.Interfaces;
using AirlineTickets.BLL.Models;
using AirlineTickets.DAL.Entities;
using AirlineTickets.DAL.Interfaces;
using AutoMapper;

namespace AirlineTickets.BLL.Services
{
    public class AirlineTicketCityService : GenericService<AirlineTicketCity, AirlineTicketCityEntity>, IAirlineTicketCityService
    {
        private readonly IAirlineTicketCityRepository _airlineTicketCityRepository;
        private readonly IMapper _mapper;

        public AirlineTicketCityService(IAirlineTicketCityRepository airlineTicketCityRepository, IMapper mapper) : base(airlineTicketCityRepository, mapper)
        {
            _airlineTicketCityRepository = airlineTicketCityRepository;
            _mapper = mapper;
        }

        public async Task<AirlineTicketCity> Delete(int ticketId, int cityId, CancellationToken cancellationToken)
        {
            var ticketCity = await _airlineTicketCityRepository.GetById(ticketId, cityId, cancellationToken);

            if (ticketCity is not null)
            {
                await _airlineTicketCityRepository.Delete(ticketId, cityId, cancellationToken);
            }

            return _mapper.Map<AirlineTicketCity>(ticketCity);
        }

        public async Task<AirlineTicketCity> Get(int ticketId, int cityId, CancellationToken cancellationToken)
        {
            var ticketCity = await _airlineTicketCityRepository.GetById(ticketId, cityId, cancellationToken);

            return _mapper.Map<AirlineTicketCity>(ticketCity);
        }
    }
}
