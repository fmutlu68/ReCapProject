using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.ErrorCodes;
using Business.Constants.ErrorMessages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //[SecuredOperation("Admin,Car.add","Result")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.GetCRUDSuccess(_carDal.GetAll().Count,"Araba","Ekleme"));
        }

        //[SecuredOperation("Admin,Car.listdetails", "DataResult", "ListCar")]
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            try
            {
                return new SuccessDataResult<List<CarDetailDto>>(Messages.GetEntityListedSuccess,_carDal.GetCarDetails());
            }
            catch (Exception err)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.GetEntityListedError(err.Message));
            }
        }

        //[SecuredOperation("Admin,Car.listbybrand", "DataResult", "ListCar")]
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
            }
            catch (Exception err)
            {
                return new ErrorDataResult<List<Car>>(Messages.GetEntityListedError(err.Message));
            }
        }

        //[SecuredOperation("Admin,Car.listbycolor", "DataResult", "ListCar")]
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
            }
            catch (Exception err)
            {
                return new ErrorDataResult<List<Car>>(Messages.GetEntityListedError(err.Message));
            }
        }

        //[SecuredOperation("Admin,Car.update", "Result")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.GetCRUDSuccess(_carDal.GetAll().Count, "Araba", "Güncelleme"));
        }

        //[SecuredOperation("Admin,Car.list", "DataResult", "ListCar")]
        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(Messages.GetEntityListedSuccess,_carDal.GetAll());
        }

        //[SecuredOperation("Admin,Car.delete", "Result", "List")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.GetCRUDSuccess(_carDal.GetAll().Count,"Araba","Silme"));
        }

        [CacheAspect]
        //[SecuredOperation("Admin,Car.getbyid", "DataResult", "Car")]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(Messages.GetEntitySuccess("Arabayı"),_carDal.Get(c=>c.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarDetailsByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(Messages.GetEntityListedSuccess,_carDal.GetCarDetails(c=>c.ColorId == colorId));
        }
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(Messages.GetEntityListedSuccess, _carDal.GetCarDetails(c=>c.BrandId == brandId));
        }

        public IDataResult<CarDetailDto> GetCarDetailById(int carId)
        {
            var data = _carDal.GetCarDetail(c => c.CarId == carId);
            //if (data.ImageList == null || data.ImageList.Count == 0)
            //{
            //    return new SuccessDataResult<CarDetailDto>($" {ErrorCodes.GetNotFoundErrorCode}-{ErrorMessages.GetDoesntExistsAnyImageError}",data);
            //}
            return new SuccessDataResult<CarDetailDto>(Messages.GetEntitySuccess("Araba Resmi"), data);
        }
    }
}
