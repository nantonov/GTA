using Messages;
using FluentValidation;

namespace AirlineTicketsNotifications.API.Validation.Validators
{
    public class TicketInfoValidator : AbstractValidator<NewTicketInfoMessage>
    {
        public TicketInfoValidator()
        {
            RuleFor(i => i.StayingStatus).IsInEnum();
            RuleFor(i => i.CityName).MaximumLength(150).NotEmpty();
        }
    }
}
