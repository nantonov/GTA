using AirlineTickets.API.ViewModels.AirlineTicket;
using FluentValidation;

namespace AirlineTickets.API.Validation.Validators
{
    public class AirlineTicketValidator : AbstractValidator<CreateUpdateTicketViewModel>
    {
        public AirlineTicketValidator()
        {
            RuleFor(t => t.PassengerCredentials).NotEmpty().MaximumLength(200);
            RuleFor(t => t.DepartureTime).NotNull();
            RuleFor(t => t.ArrivalTime).NotNull();
            RuleFor(t => t.Price).NotNull();
        }
    }
}
