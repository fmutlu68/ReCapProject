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
        public IDataResult<List<CarImage>> GetAllImagesByCarId(int categoryId)
        {
            IDataResult<List<CarImage>> images = new SuccessDataResult<List<CarImage>>();
            return images;
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

            base.service.Add(carImage);
            return new SuccessResult("");
        }
        public IResult DeleteImage(CarImage carImage)
        {
            IResult result = FileHelper.Delete(carImage.ImagePath);
            base.service.Delete(carImage);
            return new SuccessResult();
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

            base.service.Update(carImage);
            return new SuccessResult();
        }
        public IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\Images\defaultimage.jpg";
                var result = base.service.GetAll(c => c.CarId == id).Count > 0 ? true : false;
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);

                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(base.service.GetAll(c => c.CarId == id));
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
