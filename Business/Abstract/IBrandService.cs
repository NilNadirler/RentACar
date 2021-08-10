using Core.Result;
using Entities.Concentre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Delete(Brand brand);
        IResult Update(Brand brand);

        IDataResult<List<Brand>> GetByName(string name);
        IDataResult<List<Brand>> GetAll();
        IDataResult <List<Brand>> GetBrandId(int id);
    }
}
