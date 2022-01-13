using DataAccess.Abstract;
using DataAccess.Concentre.EntityFramework;
using Entities.Concentre;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
   public  class BrandValidator: AbstractValidator<Brand>

    {
        public IBrandDal _brandDal;
        public BrandValidator()
        {
            _brandDal = new EfBrandDal();
            RuleFor(b => b.BrandName).MinimumLength(2);
            RuleFor(b => b.BrandName).Must(IsNameUnique).WithMessage("Already in Brand Name");
          
        }
        public bool IsNameUnique(string name)
        {
            return _brandDal.IsUnique(name);

        }
    }
}
