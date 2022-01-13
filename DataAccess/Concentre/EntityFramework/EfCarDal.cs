
using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concentre;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concentre.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarDetailDto> GetByBrandId(int brandId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             where c.BrandId==brandId
                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarId = c.Id,



                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetByColorId(int colorId)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             where c.ColorId == colorId
                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarId = c.Id,



                             };
                return result.ToList();

            }
        }

        public List<CarDetailDto> GetDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarId=c.Id,
                                
                                 

                             };
                return result.ToList();

            }
        }

        public CarDetailDto GetById(int id)
        {
            using (RecapContext context = new RecapContext())
            {
                var list = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             where c.Id == id
                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarId = c.Id,
                                 BrandId = b.BrandId,
                                 ColorId = c.ColorId
                             };
                var result= new CarDetailDto();
                if (list.ToList().Count > 0)
                    result = list.ToList()[0];
                return result;

            }
        }

        public List<CarDetailDto> GetDetailsByFilter(CarDetailDto dto)
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             where b.BrandName.Contains(dto.BrandName) ||
                             co.ColorName.Contains(dto.ColorName) ||
                             (dto.DailyPrice !=0 && c.DailyPrice.ToString().Contains(dto.DailyPrice.ToString())) ||
                             (dto.ModelYear != 0 && c.ModelYear.ToString().Contains(dto.ModelYear.ToString()))
                             select new CarDetailDto
                             {
                                 Description = c.Description,
                                 ColorName = co.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 CarId = c.Id
                             };
                return result.ToList();

            }
        }
    }
}
