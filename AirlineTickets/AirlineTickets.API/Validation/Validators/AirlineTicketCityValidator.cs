using AirlineTickets.API.ViewModels.AirlineTicketCity;
using FluentValidation;

namespace AirlineTickets.API.Validation.Validators
{
    public class AirlineTicketCityValidator : AbstractValidator<CreateUpdateTicketCityViewModel>
    {
        public AirlineTicketCityValidator()
        {
            RuleFor(tc => tc.AirlineTicketId).NotEmpty();
            RuleFor(tc => tc.CityId).NotEmpty();
            RuleFor(tc => tc.StayingStatus).IsInEnum();
        }
    }
}
