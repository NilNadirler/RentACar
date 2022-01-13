
using Core.DataAccess;
using Entities.Concentre;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal : IEntityRepository<Brand>
    {
        public bool IsUnique(string name);
    }
}
