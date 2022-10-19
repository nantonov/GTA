using AirlineTickets.API.ViewModels.Hotel;
using FluentValidation;

namespace AirlineTickets.API.Validation.Validators
{
    public class HotelValidator : AbstractValidator<CreateUpdateHotelViewModel>
    {
        public HotelValidator()
        {
            RuleFor(h => h.Name).NotEmpty().MaximumLength(150);
            RuleFor(h => h.StarsNumber).NotEmpty();
            RuleFor(h => h.RoomsNumber).NotEmpty();
        }
    }
}
