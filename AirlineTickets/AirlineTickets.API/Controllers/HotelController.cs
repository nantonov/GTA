using AirlineTickets.API.ViewModels.Hotel;
using AirlineTickets.BLL.Interfaces;
using AirlineTickets.BLL.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTickets.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IGenericService<Hotel> _hotelService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUpdateHotelViewModel> _hotelValidator;

        public HotelController(IGenericService<Hotel> hotelService, IMapper mapper,
            IValidator<CreateUpdateHotelViewModel> hotelValidator)
        {
            _hotelService = hotelService;
            _mapper = mapper;
            _hotelValidator = hotelValidator;
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
            await _hotelValidator.ValidateAndThrowAsync(createModel, cancellationToken);

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
            await _hotelValidator.ValidateAndThrowAsync(updateModel, cancellationToken);

            var model = _mapper.Map<Hotel>(updateModel);
            model.Id = id;

            var hotel = await _hotelService.Update(model, cancellationToken);

            return _mapper.Map<HotelViewModel>(hotel);
        }
    }
}