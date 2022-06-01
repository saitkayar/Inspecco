using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator()
        {
            RuleFor(e => e.UserName).NotEmpty().NotNull().NotEqual("string");
            RuleFor(e => e.Email).EmailAddress().WithMessage("Email adresinizi kontrol ediniz.");
            
            RuleFor(e => e.Password).NotEmpty().MaximumLength(2);
        }
    }
   
}
