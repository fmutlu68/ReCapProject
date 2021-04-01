using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [CacheAspect]
        //[SecuredOperation("Admin,CarImage.listbycarid", "DataResult", "ListCarImage")]
        public IDataResult<List<CarImage>> GetAllImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(Messages.GetEntityListedSuccess, _carImageDal.GetAll(c => c.CarId == carId));
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

            return Add(carImage);
        }
        public IResult DeleteImage(int id)
        {
            CarImage willDeletedImage = _carImageDal.Get(img=>img.Id == id);
            IResult result = FileHelper.Delete(willDeletedImage.ImagePath);
            if (result.Success == false)
            {
                return result;
            }
            return Delete(willDeletedImage);
        }
        public IResult UpdateImage(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImagesLimitWasExceded(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(i => i.Id == carImage.Id).ImagePath;

            carImage.ImagePath = FileHelper.Update(oldPath, file);
            carImage.Date = DateTime.Now;

            return Update(carImage);
        }

        private IResult CheckIfImagesLimitWasExceded(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id).Count;
            if (result >= 5)
            {
                return new ErrorResult("Resim ekleme limiti aşıldığı için eklenemedi!");
            }
            return new SuccessResult();
        }

        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [SecuredOperation("Admin,CarImage.add", "Result")]
        public IResult Add(CarImage entity)
        {
            _carImageDal.Add(entity);
            return new SuccessResult(Messages.GetCRUDSuccess(_carImageDal.GetAll().Count, "Araba Resimleri", "Ekleme"));
        }

        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [SecuredOperation("Admin,CarImage.delete", "Result")]
        public IResult Delete(CarImage entity)
        {
            _carImageDal.Delete(entity);
            return new SuccessResult(Messages.GetCRUDSuccess(_carImageDal.GetAll().Count, "Araba Resimleri", "Silme"));
        }

        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [SecuredOperation("Admin,CarImage.update", "Result")]
        public IResult Update(CarImage entity)
        {
            _carImageDal.Update(entity);
            return new SuccessResult(Messages.GetCRUDSuccess(_carImageDal.GetAll().Count, "Araba Resimleri", "Güncelleme"));
        }

        [CacheAspect]
        //[SecuredOperation("Admin,CarImage.list", "DataResult", "ListCarImage")]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(Messages.GetEntityListedSuccess,_carImageDal.GetAll());
        }

        [CacheAspect]
        //[SecuredOperation("Admin,CarImage.getbyid", "DataResult", "CarImage")]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(Messages.GetEntitySuccess("Araba Resimi"),_carImageDal.Get(img=>img.Id == id));
        }
    }
}
