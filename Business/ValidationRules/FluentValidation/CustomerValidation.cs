using Entities.Concentre;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class CustomerValidation: AbstractValidator<Customer>

    {
        public CustomerValidation()
        {
            RuleFor(c => c.CompanyName).MinimumLength(2);
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
