using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concentre;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concentre.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RecapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RecapContext context = new RecapContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.Id equals r.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.Id
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join u in context.Users
                             on r.CustomerId equals u.Id
                             
                             select new RentalDetailDto
                             {
                                 CompanyName = cu.CompanyName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 FullName= u.FirstName+u.LastName,
                                 BrandName= b.BrandName,
                                 RentalId= r.Id

                                 
                             };
                return result.ToList();
            }
        }
    }
}
