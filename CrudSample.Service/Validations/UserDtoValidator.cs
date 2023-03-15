using CrudSample.Core.DTOs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CrudSample.Service.Validations
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {

        public UserDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("{PropertyName} is required")
                                 .EmailAddress().WithMessage("A valid email is required");

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(x => x.SurName).NotNull().NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(customer => customer.Password).MaximumLength(8).WithMessage("You can enter maximum 8 characters")
           .NotEmpty().WithMessage("{PropertyName} is required")
           .Must(IsPasswordValid).WithMessage("Your password should contain at least eight characters, at least one letter and a number.!");

        }
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }

}
