using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concentre;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concentre.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, RecapContext>, IBrandDal
    {
        public bool IsUnique(string name)
        {
            using (RecapContext context = new RecapContext())
            {
                return context.Set<Brand>().Where(item=>item.BrandName==name).ToList().Count==0;
            }
        }
    }
}
