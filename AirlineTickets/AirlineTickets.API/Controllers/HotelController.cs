using AirlineTickets.API.ViewModels.City;
using AirlineTickets.API.ViewModels.Hotel;
using AirlineTickets.Business.Interfaces;
using AirlineTickets.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTickets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IGenericService<Hotel> _hotelService;
        private readonly IMapper _mapper;

        public HotelController(IGenericService<Hotel> hotelService, IMapper mapper)
        {
            _hotelService = hotelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<HotelViewModel>> GetAll(CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<HotelViewModel>>(await _hotelService.GetAll(cancellationToken));

        [HttpGet("{id}")]
        public async Task<HotelViewModel> GetById(int id, CancellationToken cancellationToken) =>
            _mapper.Map<HotelViewModel>(await _hotelService.Get(id, cancellationToken));

        [HttpPost]
        public async Task<HotelViewModel> Create([FromBody] CreateUpdateHotelViewModel createModel, CancellationToken cancellationToken)
        {
            var hotel = await _hotelService.Create(_mapper.Map<Hotel>(createModel), cancellationToken);

            return _mapper.Map<HotelViewModel>(hotel);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _hotelService.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<HotelViewModel> Update(int id, [FromBody] CreateUpdateHotelViewModel updateModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Hotel>(updateModel);
            model.Id = id;

            var hotel = await _hotelService.Update(model, cancellationToken);

            return _mapper.Map<HotelViewModel>(hotel);
        }
    }
}