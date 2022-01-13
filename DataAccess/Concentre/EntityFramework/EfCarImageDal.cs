using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concentre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concentre.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, RecapContext>, ICarImageDal
    {
        public List<CarImage> GetByCarID(int Carid)
        {
                using(RecapContext context= new RecapContext())
            {
                var result = from c in context.Cars
                             join ci in context.CarImages
                             on c.Id equals ci.CarId
                             where ci.CarId == Carid
                             select new CarImage
                             {
                                 Id=c.Id,
                                 CarId=ci.CarId,
                                 ImagePath=ci.ImagePath,
                                 Date=ci.Date
                                 
                             };
                return result.ToList();
            } 
        }
    }
}
