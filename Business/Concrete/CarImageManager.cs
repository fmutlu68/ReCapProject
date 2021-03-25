using Business.Abstract;
using Core.Business.EntityFrameworkBusiness;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager<TDal> : EfBusinessServiceBase<CarImage, TDal>, ICarImageService
        where TDal : class, IDal<CarImage>, new()
    {
        public IDataResult<List<CarImage>> GetAllImagesByCarId(int carId)
        {
            List<CarImage> images = base.service.GetAll(img=>img.CarId == carId);
            return new SuccessDataResult<List<CarImage>>("Resimler Listelendi.",images);
        }
        public IResult AddImage(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImagesLimitWasExceded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;

            return base.Add(carImage);
        }
        public IResult DeleteImage(int id)
        {
            CarImage willDeletedImage = base.service.Get(img=>img.Id == id);
            IResult result = FileHelper.Delete(willDeletedImage.ImagePath);
            if (result.Success == false)
            {
                return result;
            }
            return base.Delete(willDeletedImage);
        }
        public IResult UpdateImage(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImagesLimitWasExceded(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + base.service.Get(i => i.Id == carImage.Id).ImagePath;

            carImage.ImagePath = FileHelper.Update(oldPath, file);
            carImage.Date = DateTime.Now;

            return base.Update(carImage);
        }

        private IResult CheckIfImagesLimitWasExceded(int id)
        {
            var result = base.service.GetAll(c => c.CarId == id).Count;
            if (result >= 5)
            {
                return new ErrorResult("Resim ekleme limiti aşıldığı için eklenemedi!");
            }
            return new SuccessResult();
        }
    }
}
