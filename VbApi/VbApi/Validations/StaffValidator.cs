using FluentValidation;
using VbApi.Controllers;

namespace VbApi.Validations
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(10).WithMessage("Name must be at least 10 characters long.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email address format.");

            RuleFor(x => x.Phone)
                .Matches(@"^\d+$").WithMessage("Phone number can only contain digits.")
                .Length(10).WithMessage("Phone number must be 10 digits long.");

            RuleFor(x => x.HourlySalary)
                .InclusiveBetween(30, 400).WithMessage("Hourly salary must be between 30 and 400.");
        }
    }
}
