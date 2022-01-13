using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concentre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concentre
{
    public class ColorManager : IColorService

    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color user)
        {
            _colorDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(Color user)
        {
            _colorDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetbyId(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }

        public IDataResult<List<Color>> GetbyName(string name)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorName == name));

        }

        public IResult Update(Color user)
        {
            throw new NotImplementedException();
        }

        
    }
}
