using AirlineTickets.API.ViewModels.AirlineTicketCity;
using AirlineTickets.API.ViewModels.TicketInfo;
using AirlineTickets.BLL.Interfaces;
using AirlineTickets.BLL.Models;
using AirlineTickets.Core.Constants;
using AutoMapper;
using FluentValidation;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTickets.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AirlineTicketCityController : ControllerBase
    {
        private readonly IAirlineTicketCityService _ticketCityService;
        private readonly IGenericService<City> _cityService; 
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUpdateTicketCityViewModel> _ticketCityValidator;
        private readonly IHttpClientFactory _httpClientFactory;

        public AirlineTicketCityController(IAirlineTicketCityService ticketCityService, IGenericService<City> cityService,
            IMapper mapper, IValidator<CreateUpdateTicketCityViewModel> hotelValidator, IHttpClientFactory httpClientFactory)
        {
            _ticketCityService = ticketCityService;
            _cityService = cityService;
            _mapper = mapper;
            _ticketCityValidator = hotelValidator;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IEnumerable<TicketCityViewModel>> GetAll(CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<TicketCityViewModel>>(await _ticketCityService.GetAll(cancellationToken));

        [HttpGet("Ticket/{ticketId}/City/{cityId}")]
        public async Task<TicketCityViewModel> GetById(int ticketId, int cityId, CancellationToken cancellationToken) =>
            _mapper.Map<TicketCityViewModel>(await _ticketCityService.Get(ticketId, cityId, cancellationToken));

        [HttpPost]
        public async Task<TicketCityViewModel> Create([FromBody] CreateUpdateTicketCityViewModel createModel, CancellationToken cancellationToken)
        {
            await _ticketCityValidator.ValidateAndThrowAsync(createModel, cancellationToken);

            var model = _mapper.Map<AirlineTicketCity>(createModel);

            var ticketCity = await _ticketCityService.Create(model, cancellationToken);

            var city = await _cityService.Get(model.CityId, cancellationToken);
            var ticketInfo = new NewTicketInfoViewModel()
            {
                StayingStatus = model.StayingStatus,
                CityName = city.Name,
            };

            var authClient = _httpClientFactory.CreateClient();
            var discoveryDocument = await authClient.GetDiscoveryDocumentAsync("https://localhost:5001", cancellationToken);

            var tokenResponse = await authClient.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = discoveryDocument.TokenEndpoint,
                    ClientId = AuthValues.TicketsClientId,
                    ClientSecret = AuthValues.TicketsClientSecret,
                    Scope = AuthValues.NotificationsScopeName
                }, cancellationToken);

            var notificationsClient = _httpClientFactory.CreateClient();

            notificationsClient.SetBearerToken(tokenResponse.AccessToken);

            await notificationsClient.PostAsJsonAsync(AuthValues.NotificationsEventPath, ticketInfo, cancellationToken);

            return _mapper.Map<TicketCityViewModel>(ticketCity);
        }

        [HttpDelete("Ticket/{ticketId}/City/{cityId}")]
        public async Task Delete(int ticketId, int cityId, CancellationToken cancellationToken)
        {
            await _ticketCityService.Delete(ticketId, cityId, cancellationToken);
        }

        [HttpPut]
        public async Task<TicketCityViewModel> Update([FromBody] CreateUpdateTicketCityViewModel updateModel, CancellationToken cancellationToken)
        {
            await _ticketCityValidator.ValidateAndThrowAsync(updateModel, cancellationToken);

            var model = _mapper.Map<AirlineTicketCity>(updateModel);

            var ticketCity = await _ticketCityService.Update(model, cancellationToken);

            return _mapper.Map<TicketCityViewModel>(ticketCity);
        }
    }
}