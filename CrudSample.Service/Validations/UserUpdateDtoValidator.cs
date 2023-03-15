using CrudSample.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrudSample.Service.Validations
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {

            RuleFor(x => x.Email).EmailAddress().WithMessage("A valid email is required");
        }
      
    }
}
