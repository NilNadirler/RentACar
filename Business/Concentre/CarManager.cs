using Business.Abstract;
using Entities.Concentre;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.Result;
using Business.Constants;
using Core.Utilities.Results;
using FluentValidation;
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
        public IDataResult< List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(default,Messages.MaintenanceTime);
            }
            else
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ProductAdded);
            }
     
        }

        public IDataResult <List<Car>> GetByBrandId(int id)
        {
            return new SuccessDataResult <List < Car >>( _carDal.GetAll(c => c.BrandId == id));
        }

        public IDataResult<List<Car>> GetbyColarId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=> c.Id==id));
        }

        public IDataResult <List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }
        [CacheAspect]
        public IDataResult< Car> GetbyID(int carID)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == carID));

        }

        public IDataResult<List<Car>> GetCarsModelYear(int modelYear)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == modelYear));
        }

        public IDataResult<List<CarDetailDto>> GetDetails(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetDetails());
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
