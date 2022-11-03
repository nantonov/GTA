using AirlineTickets.API.ViewModels.City;
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
    public class CityController : ControllerBase
    {
        private readonly IGenericService<City> _cityService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUpdateCityViewModel> _cityValidator;

        public CityController(IGenericService<City> cityService, IMapper mapper,
            IValidator<CreateUpdateCityViewModel> cityValidator)
        {
            _cityService = cityService;
            _mapper = mapper;
            _cityValidator = cityValidator;
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
            await _cityValidator.ValidateAndThrowAsync(createModel, cancellationToken);

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
            await _cityValidator.ValidateAndThrowAsync(updateModel, cancellationToken);

            var model = _mapper.Map<City>(updateModel);
            model.Id = id;

            var city = await _cityService.Update(model, cancellationToken);

            return _mapper.Map<CityViewModel>(city);
        }
    }
}