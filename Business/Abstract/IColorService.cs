using Core.Result;
using Entities.Concentre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetbyId(int id);
        IDataResult <List<Color>> GetbyName(string Colorname);
        IResult Add(Color user);
        IResult Delete(Color user);
        IResult Update(Color user);
    }
}
