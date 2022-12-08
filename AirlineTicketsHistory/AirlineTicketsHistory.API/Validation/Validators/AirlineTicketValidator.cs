using AirlineTicketsHistory.API.ViewModels.AirlineTicket;
using FluentValidation;

namespace AirlineTicketsHistory.API.Validation.Validators
{
    public class AirlineTicketValidator : AbstractValidator<CreateAirlineTicketViewModel>
    {
        public AirlineTicketValidator() 
        {
            RuleFor(t => t.UserId).NotEmpty();
            RuleFor(t => t.TicketId).NotEmpty();
            RuleFor(t => t.PassengerCredentials).NotEmpty().MaximumLength(200);
            RuleFor(t => t.DepartureTime).NotNull();
            RuleFor(t => t.ArrivalTime).NotNull();
            RuleFor(t => t.Price).NotNull();
        }
    }
}
