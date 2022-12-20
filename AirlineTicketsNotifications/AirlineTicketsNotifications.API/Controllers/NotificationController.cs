using AirlineTicketsNotifications.API.ViewModels.NotificationRequest;
using AirlineTicketsNotifications.BLL.Interfaces;
using AirlineTicketsNotifications.BLL.Models.Requests;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirlineTicketsNotifications.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateNotificationRequestViewModel> _requestValidator;

        public NotificationController(INotificationService notificationService, IMapper mapper, 
            IValidator<CreateNotificationRequestViewModel> requestValidator)
        {
            _notificationService = notificationService;
            _mapper = mapper;
            _requestValidator = requestValidator;
        }

        [HttpPost("Request")]
        public async Task<NotificationRequestViewModel> CreateNotificationRequest(
            [FromBody] CreateNotificationRequestViewModel requestModel, CancellationToken cancellationToken)
        {
            await _requestValidator.ValidateAndThrowAsync(requestModel, cancellationToken);

            var model = _mapper.Map<NotificationRequest>(requestModel);

            var request = await _notificationService.CreateNotificationRequest(model, cancellationToken);

            return _mapper.Map<NotificationRequestViewModel>(request);
        }
    }
}
