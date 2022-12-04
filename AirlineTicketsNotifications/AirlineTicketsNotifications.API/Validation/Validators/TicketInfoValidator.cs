using AirlineTicketsNotifications.API.ViewModels.TicketInfo;
using FluentValidation;

namespace AirlineTicketsNotifications.API.Validation.Validators
{
    public class TicketInfoValidator : AbstractValidator<NewTicketInfoViewModel>
    {
        public TicketInfoValidator()
        {
            RuleFor(i => i.StayingStatus).IsInEnum();
            RuleFor(i => i.CityName).MaximumLength(150).NotEmpty();
        }
    }
}
