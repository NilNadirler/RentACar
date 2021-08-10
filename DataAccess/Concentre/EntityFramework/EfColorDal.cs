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
    public class EfColorDal : EfEntityRepositoryBase<Color, RecapContext>, IColorDal
    {

    }
}
