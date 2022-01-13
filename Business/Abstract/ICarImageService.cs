using Core.Result;
using Entities.Concentre;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage,IFormFile file, IWebHostEnvironment env);
        IResult Update(CarImage carImage, IFormFile file, IWebHostEnvironment env);
        IResult Delete(CarImage carImage, IWebHostEnvironment env);
        IDataResult<string> GetBase64(string imagePath, IWebHostEnvironment env);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarID(int id);
        IDataResult<List<CarImage>> GetImagePath(string imagepath);
        IDataResult<List<CarImage>> GetDate(DateTime date);
       



    }
}
