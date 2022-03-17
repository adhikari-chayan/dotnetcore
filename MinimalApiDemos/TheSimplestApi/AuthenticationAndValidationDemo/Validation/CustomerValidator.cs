using AuthenticationAndValidationDemo.Models;
using FluentValidation;

namespace AuthenticationAndValidationDemo.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().MinimumLength(2);
        }
    }
}
