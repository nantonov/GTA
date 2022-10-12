using AirlineTickets.API.ViewModels.AirlineTicket;
using AirlineTickets.Business.Interfaces;
using AirlineTickets.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTickets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirlineTicketController : ControllerBase
    {
        private readonly IGenericService<AirlineTicket> _airlineTicketService;
        private readonly IMapper _mapper;

        public AirlineTicketController(IGenericService<AirlineTicket> airlineTicketService, IMapper mapper)
        {
            _airlineTicketService = airlineTicketService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IEnumerable<TicketViewModel>> GetAll(CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<TicketViewModel>>(await _airlineTicketService.GetAll(cancellationToken));

        [HttpGet("{id}")]
        public async Task<TicketViewModel> GetById(int id, CancellationToken cancellationToken) =>
            _mapper.Map<TicketViewModel>(await _airlineTicketService.Get(id, cancellationToken));

        [HttpPost()]
        public async Task<TicketViewModel> Create([FromBody] CreateUpdateTicketViewModel createModel, CancellationToken cancellationToken)
        {
            var ticket = await _airlineTicketService.Create(_mapper.Map<AirlineTicket>(createModel), cancellationToken);

            return _mapper.Map<TicketViewModel>(ticket);
        }

        [HttpDelete()]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _airlineTicketService.Delete(id, cancellationToken);
        }

        [HttpPut()]
        public async Task<TicketViewModel> Update(int id, [FromBody] CreateUpdateTicketViewModel updateModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<AirlineTicket>(updateModel);
            model.Id = id;

            var ticket = await _airlineTicketService.Update(model, cancellationToken);

            return _mapper.Map<TicketViewModel>(ticket);
        }
    }
}