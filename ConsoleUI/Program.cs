using Business.Concentre;
using DataAccess.Concentre.EntityFramework;
using Entities.Concentre;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager c = new CarManager(new EfCarDal());
            var result = c.Delete(new Car { ID = 4 });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }



            Console.ReadLine();
        }

        private static Core.Result.IResult dedeme()
        {
            CarManager cnm = new CarManager(new EfCarDal());
            var result = cnm.Add(new Car { BrandId = 5, ColorId = 3, Description = "Mercedes", DailyPrice = 130, ModelYear = 2012 });
            return result;
        }

        private static void CustomerAdd()
        {
            CustomerManager c = new CustomerManager(new EfCustomerDal());
            var result = c.Add(new Customer { Id = 5, CompanyName = "bbb", UserId = 3 });
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);

            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }

        private static void AddTest()
        {
            CarManager cm = new CarManager(new EfCarDal());


            cm.Add(new Car { BrandId = 2, DailyPrice = 120, ColorId = 2, ModelYear = 2018, Description = "Bmw" });
            Console.WriteLine("Data Eklendi");
        }

        private static void DeleteTest()
        {
            CarManager cm = new CarManager(new EfCarDal());
            cm.Delete(new Car { ID = 2 });
            Console.WriteLine("Data silindi");
        }

        private static void GetByBrandTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetByBrandId(2);
            foreach (var item in result.Data)
            {
                if (result.Success == true)
                {
                    Console.WriteLine(item.DailyPrice + " " + item.BrandId + " " + item.ColorId);
                }

            }
        }
    }
}
