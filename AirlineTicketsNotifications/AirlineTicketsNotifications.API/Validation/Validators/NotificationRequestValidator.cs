using AirlineTicketsNotifications.API.ViewModels.NotificationRequest;
using FluentValidation;

namespace AirlineTicketsNotifications.API.Validation.Validators
{
    public class NotificationRequestValidator : AbstractValidator<CreateNotificationRequestViewModel>
    {
        public NotificationRequestValidator()
        {
            RuleFor(r => r.Email).MaximumLength(250).NotEmpty();
            RuleFor(r => r.StayingStatus).IsInEnum();
            RuleFor(r => r.CityName).MaximumLength(150).NotEmpty();
        }
    }
}
