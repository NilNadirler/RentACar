using DataAccess.Abstract;
using Entities.Concentre;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concentre.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal(List<Car> cars)
        {
            _cars = cars;
            new Car { BrandId = 3, ColorId = 2, DailyPrice = 130, Description = "Renault", Id = 1, ModelYear = 2018 };
            new Car { BrandId = 6, ColorId = 2, DailyPrice = 150, Description = "Honda", Id = 2, ModelYear = 2012 };
            new Car { BrandId = 5, ColorId = 2, DailyPrice = 120, Description = "Bmv", Id = 3, ModelYear = 2020 };
            new Car { BrandId = 5, ColorId = 2, DailyPrice = 110, Description = "Mercedes", Id = 4, ModelYear = 2016 };
        }

        public void Add(Car cars)
        {
            _cars.Add(cars);
        }

        public void Delete(Car cars)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == cars.Id);
            _cars.Remove(cars);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }



        public List<Car> GetAll(Expression<Func<Car, bool>> filter)
        {
            return _cars;
        }

        public void Update(Car cars)
        {
            Car toUpdate = _cars.SingleOrDefault(u => u.Id == cars.Id);
            toUpdate.ColorId = cars.ColorId;

        }

        public List<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Car> Where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public void Insert(Car entity)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public CarDetailDto GetById(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetDetailsByFilter(CarDetailDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
