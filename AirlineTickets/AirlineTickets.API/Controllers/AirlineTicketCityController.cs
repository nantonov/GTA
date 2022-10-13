using AirlineTickets.API.ViewModels.AirlineTicketCity;
using AirlineTickets.Business.Interfaces;
using AirlineTickets.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTickets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirlineTicketCityController : ControllerBase
    {
        private readonly IAirlineTicketCityService _ticketCityService;
        private readonly IMapper _mapper;

        public AirlineTicketCityController(IAirlineTicketCityService ticketCityService, IMapper mapper)
        {
            _ticketCityService = ticketCityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<TicketCityViewModel>> GetAll(CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<TicketCityViewModel>>(await _ticketCityService.GetAll(cancellationToken));

        [HttpGet("Ticket{ticketId}/City{cityId}")]
        public async Task<TicketCityViewModel> GetById(int ticketId, int cityId, CancellationToken cancellationToken) =>
            _mapper.Map<TicketCityViewModel>(await _ticketCityService.Get(ticketId, cityId, cancellationToken));

        [HttpPost]
        public async Task<TicketCityViewModel> Create([FromBody] CreateUpdateTicketCityViewModel createModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<AirlineTicketCity>(createModel);

            var ticketCity = await _ticketCityService.Create(model, cancellationToken);

            return _mapper.Map<TicketCityViewModel>(ticketCity);
        }

        [HttpDelete("Ticket{ticketId}/City{cityId}")]
        public async Task Delete(int ticketId, int cityId, CancellationToken cancellationToken)
        {
            await _ticketCityService.Delete(ticketId, cityId, cancellationToken);
        }

        [HttpPut]
        public async Task<TicketCityViewModel> Update([FromBody] CreateUpdateTicketCityViewModel updateModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<AirlineTicketCity>(updateModel);

            var ticketCity = await _ticketCityService.Update(model, cancellationToken);

            return _mapper.Map<TicketCityViewModel>(ticketCity);
        }
    }
}