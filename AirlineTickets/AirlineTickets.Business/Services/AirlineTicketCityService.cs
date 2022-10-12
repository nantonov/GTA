using AirlineTickets.Business.Interfaces;
using AirlineTickets.Business.Models;
using AirlineTickets.Data.Entities;
using AirlineTickets.Data.Interfaces;
using AutoMapper;

namespace AirlineTickets.Business.Services
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

        public async Task Delete(int ticketId, int cityId, CancellationToken cancellationToken)
        {
            await _airlineTicketCityRepository.Delete(ticketId, cityId, cancellationToken);
        }

        public async Task<AirlineTicketCity> Get(int ticketId, int cityId, CancellationToken cancellationToken)
        {
            var ticketCity = await _airlineTicketCityRepository.GetById(ticketId, cityId, cancellationToken);

            return _mapper.Map<AirlineTicketCity>(ticketCity);
        }
    }
}
