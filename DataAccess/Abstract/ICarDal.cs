
using Core.DataAccess;
using Entities.Concentre;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;


namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetDetails();
        List<CarDetailDto> GetDetailsByFilter(CarDetailDto dto);
        List<CarDetailDto> GetByBrandId(int brandId);
        List<CarDetailDto> GetByColorId(int colorId);
        CarDetailDto GetById(int carId);



    }
}
