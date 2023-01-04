using AirlineTicketsHistory.API.ViewModels.AirlineTicket;
using AirlineTicketsHistory.API.ViewModels.TicketsHistory;
using AirlineTicketsHistory.BLL.Interfaces;
using AirlineTicketsHistory.BLL.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketsHistory.API.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("History")]
    public class UserTicketsHistoryController : Controller
    {
        private readonly IUserTicketsHistoryService _historyService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateAirlineTicketViewModel> _airlineTicketValidator;

        public UserTicketsHistoryController(IUserTicketsHistoryService historyService, IMapper mapper,
            IValidator<CreateAirlineTicketViewModel> validator)
        {
            _historyService = historyService;
            _mapper = mapper;
            _airlineTicketValidator = validator;
        }

        [HttpGet]
        public async Task<IEnumerable<UserTicketsHistoryViewModel>> GetAll(CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<UserTicketsHistoryViewModel>>(await _historyService.GetAll(cancellationToken));

        [HttpGet("{userId}")]
        public async Task<UserTicketsHistoryViewModel> GetByUserId(string userId, CancellationToken cancellationToken) =>
            _mapper.Map<UserTicketsHistoryViewModel>(await _historyService.GetByUserId(userId, cancellationToken));

        [HttpDelete("{userId}")]
        public async Task Delete(string userId, CancellationToken cancellationToken) =>
            await _historyService.Delete(userId, cancellationToken);

        [HttpPost("Ticket")]
        public async Task<UserTicketsHistoryViewModel> AddTicketToUserHistory(CreateAirlineTicketViewModel createModel, CancellationToken cancellationToken)
        {
            await _airlineTicketValidator.ValidateAndThrowAsync(createModel, cancellationToken);

            var model = _mapper.Map<AirlineTicket>(createModel);

            if (string.IsNullOrEmpty(createModel.UserId))
            {
                return new UserTicketsHistoryViewModel();
            }

            var userHistory = await _historyService.AddTicketToUserHistory(createModel.UserId, model, cancellationToken);

            return _mapper.Map<UserTicketsHistoryViewModel>(userHistory);
        }

        [HttpDelete("Ticket/{ticketId}/User/{userId}")]
        public async Task<UserTicketsHistoryViewModel> RemoveTicketFromUserHistory(int ticketId, string userId, CancellationToken cancellationToken) =>
            _mapper.Map<UserTicketsHistoryViewModel>(await _historyService.RemoveTicketFromUserHistory(userId, ticketId, cancellationToken));
    }
}
