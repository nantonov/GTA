using AirlineTickets.API.ViewModels.City;
using AirlineTickets.Business.Interfaces;
using AirlineTickets.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTickets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IGenericService<City> _cityService;
        private readonly IMapper _mapper;

        public CityController(IGenericService<City> cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CityViewModel>> GetAll(CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<CityViewModel>>(await _cityService.GetAll(cancellationToken));

        [HttpGet("{id}")]
        public async Task<CityViewModel> GetById(int id, CancellationToken cancellationToken) =>
            _mapper.Map<CityViewModel>(await _cityService.Get(id, cancellationToken));

        [HttpPost]
        public async Task<CityViewModel> Create([FromBody] CreateUpdateCityViewModel createModel, CancellationToken cancellationToken)
        {
            var city = await _cityService.Create(_mapper.Map<City>(createModel), cancellationToken);

            return _mapper.Map<CityViewModel>(city);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id, CancellationToken cancellationToken)
        {
            await _cityService.Delete(id, cancellationToken);
        }

        [HttpPut("{id}")]
        public async Task<CityViewModel> Update(int id, [FromBody] CreateUpdateCityViewModel updateModel, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<City>(updateModel);
            model.Id = id;

            var city = await _cityService.Update(model, cancellationToken);

            return _mapper.Map<CityViewModel>(city);
        }
    }
}