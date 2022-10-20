using AirlineTickets.API.ViewModels.City;
using FluentValidation;

namespace AirlineTickets.API.Validation.Validators
{
    public class CityValidator : AbstractValidator<CreateUpdateCityViewModel>
    {
        public CityValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(150);
            RuleFor(c => c.Population).NotEmpty();
            RuleFor(c => c.Area).NotEmpty();
        }
    }
}
