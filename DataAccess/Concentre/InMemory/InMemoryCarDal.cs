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
            new Car { BrandId = 3, ColorId = 2, DailyPrice = 130, Description = "Renault", ID = 1, ModelYear = 2018 };
            new Car { BrandId = 6, ColorId = 2, DailyPrice = 150, Description = "Honda", ID = 2, ModelYear = 2012 };
            new Car { BrandId = 5, ColorId = 2, DailyPrice = 120, Description = "Bmv", ID = 3, ModelYear = 2020 };
            new Car { BrandId = 5, ColorId = 2, DailyPrice = 110, Description = "Mercedes", ID = 4, ModelYear = 2016 };
        }

        public void Add(Car cars)
        {
            _cars.Add(cars);
        }

        public void Delete(Car cars)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.ID == cars.ID);
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
            Car toUpdate = _cars.SingleOrDefault(u => u.ID == cars.ID);
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

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
