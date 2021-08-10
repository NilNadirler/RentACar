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
    }
}
