using Core.Result;
using Entities.Concentre;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService 
    {
         IDataResult< List<Car>> GetAll();
         IDataResult <List<CarDetailDto>> GetByBrandId(int brandId);
         IDataResult <List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetDetails(CarDetailDto? dto);
        IDataResult<List<CarDetailDto>> GetDetailsByFilter(CarDetailDto dto);
        IDataResult<CarDetailDto> GetbyID(int productID);
        IResult Add(Car car);

        IResult Update(Car car);

        IResult Delete(Car car);

        IDataResult<List<CarDetailDto>> GetByColorId(int colorId);
        IDataResult<List<Car>> GetCarsModelYear(int id);
        IResult AddTransactionalTest(Car car);
       
    }
}
