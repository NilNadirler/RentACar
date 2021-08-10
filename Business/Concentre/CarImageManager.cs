using Business.Abstract;
using Business.Constants;
using Core.Result;
using Core.Utilities.Business;
using Core.Utilities.FileOperation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concentre;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concentre
{
    public class CarImageManager : ICarImageService

        
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile file, IWebHostEnvironment env)
        {
            string newImagePath = FileOperation.AddImageFile(file, env);
            if (newImagePath!="")
            {
                carImage.ImagePath = newImagePath;
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccessResult("Resim eklendi");
            }
            return new ErrorResult("Resim eklenemedi");
        }

        public IResult Delete(CarImage carImage, IWebHostEnvironment env)
        {
            carImage = _carImageDal.Get(c => c.Id == carImage.Id);
            if (FileOperation.DeleteImagePath(carImage.ImagePath, env))
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult("Resim silindi");
            }
            return new ErrorResult("Resim silinemedi");
        }
        public IResult Update(CarImage carImage, IFormFile file, IWebHostEnvironment env)
        {
            carImage=_carImageDal.Get(c => c.Id == carImage.Id);
            if (FileOperation.UpdateImageFile(file, carImage.ImagePath, env))
            {
                carImage.Date = DateTime.Now;
                _carImageDal.Update(carImage);
                return new SuccessResult("Resim güncellendi");
            }
            return new ErrorResult("Resim güncellenemedi");
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetbyCarID(int Carid)


        {

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=> c.CarId==Carid));

        }

        public IDataResult<List<CarImage>> GetDate(DateTime date)
        {
            var result = _carImageDal.GetAll(c => c.Date == date);
            if (result == null)
            {
                return new ErrorDataResult<List<CarImage>>();
            }
            return new ErrorDataResult<List<CarImage>>();
        }

        public IDataResult<List<CarImage>> GetImagePath(string imagePath)
        {

            string imagepath = Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot\" + @"Pictures\SavedPictures"
           , Guid.NewGuid().ToString() + Guid.NewGuid().ToString());
            if (imagepath != null)
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.ImagePath == imagepath));

            }
            return new ErrorDataResult<List<CarImage>>();
        }


        private IResult CarIDlimitControl(int carID)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carID).Count;
            if (result<5)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarLimitAccess);
        }
    }
}
