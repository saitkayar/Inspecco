using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyValidator:AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(e=>e.CompanyName).NotNull();
            RuleFor(e=>e.CompanyName).NotEmpty();
            RuleFor(e=>e.CompanyName).MinimumLength(2);
        }
    }
}
