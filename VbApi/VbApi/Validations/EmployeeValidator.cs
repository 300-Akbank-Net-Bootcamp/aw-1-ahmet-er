using FluentValidation;
using VbApi.Controllers;

namespace VbApi.Validations
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(10).WithMessage("Name must be at least 10 characters long.")
                .MaximumLength(250).WithMessage("Name cannot exceed 250 characters.");

            RuleFor(x => x.DateOfBirth)
                .Must(BeValidBirthDate).WithMessage("Birthdate is not valid");

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email address is not valid.");

            RuleFor(x => x.Phone)
                .Matches(@"^\d+$").WithMessage("Phone number can only contain digits.")
                .Length(10).WithMessage("Phone number must be 10 digits long.");

            RuleFor(x => x.HourlySalary)
                .InclusiveBetween(50, 400).WithMessage("Hourly salary does not fall within allowed range.")
                .Must((employee, hourlySalary) => IsValidSalary(employee, hourlySalary))
                .WithMessage("Minimum hourly salary is not valid.");
        }

        private bool BeValidBirthDate(DateTime dateOfBirth)
        {
            var minAllowedBirthDate = DateTime.Today.AddYears(-65);
            return minAllowedBirthDate <= dateOfBirth;
        }

        private bool IsValidSalary(Employee employee, double hourlySalary)
        {
            var dateBeforeThirtyYears = DateTime.Today.AddYears(-30);
            var isOlderThanThirdyYears = employee.DateOfBirth <= dateBeforeThirtyYears;

            return isOlderThanThirdyYears ? hourlySalary >= 200 : hourlySalary >= 50;
        }
    }
}
