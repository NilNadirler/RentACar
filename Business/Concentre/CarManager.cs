using Business.Abstract;
using Entities.Concentre;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.Result;
using Business.Constants;
using Core.Utilities.Results;

using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Core.Aspects.Autofac.Cashing;
using Core.Aspects.Autofac.Transaction;
using Entities.DTOs;

namespace Business.Concentre
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car car)
        {

            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);

        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.UrunSil);
        }
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            var result= _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result, "Cars listed.");

        }

        public IDataResult<List<CarDetailDto>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetByBrandId(brandId));
        }



        public IDataResult<List<CarDetailDto>> GetByColorId(int ColorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetByColorId(ColorId));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }
        [CacheAspect]
        public IDataResult<CarDetailDto> GetbyID(int carID)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetById(carID));

        }

        public IDataResult<List<Car>> GetCarsModelYear(int modelYear)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == modelYear));
        }

        public IDataResult<List<CarDetailDto>> GetDetails(CarDetailDto? dto)
        {
            var result=_carDal.GetDetails().FindAll(item => dto == null || ((item.BrandName == dto.BrandName || dto.BrandName==null) &&( item.ColorName == dto.ColorName || dto.ColorName==null) && (item.ModelYear == dto.ModelYear || dto.ModelYear == 0) && (item.DailyPrice == dto.DailyPrice || dto.DailyPrice == 0)));
            return new SuccessDataResult<List<CarDetailDto>>(result,"Cars get with details.");
        }

        public IDataResult<List<CarDetailDto>> GetDetailsByFilter(CarDetailDto dto)
        {
            var result = _carDal.GetDetailsByFilter(dto);
            return new SuccessDataResult<List<CarDetailDto>>(result, "Cars get with details by filter.");
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();

        }

       
    }
}
