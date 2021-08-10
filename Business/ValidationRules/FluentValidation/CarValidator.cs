using Entities.Concentre;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p => p.BrandId).NotEmpty();
            //RuleFor(p => p.Description).Must(StartwithTr).WithMessage("Tr ile baslamali");
            RuleFor(p => p.DailyPrice).LessThan(100).When(p => p.ModelYear <= 2000);


          
        }
       

        //private bool StartwithTr(string arg)
        //{
        //    return arg.Substring(0, 2) == "Tr";
        //}
    }
}
