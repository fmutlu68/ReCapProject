using Business.Abstract;
using Core.Business.EntityFrameworkBusiness;
using Core.Constants;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager<T,TDal> : EfBusinessServiceBase<Car,T>,ICarService
        where T : class, IDal<Car>, new()
        where TDal : class, ICarDal, new()
    {
        TDal dal;

        public CarManager()
        {
            this.dal = new TDal();
        }

        public override IResult Add(Car entity)
        {
            if (entity.Description.Length <= 2)
            {
                return new ErrorResult("Araba Ekleme İşlemi Başarısız. Araba Tanımı En Az 3 Karakter Olmalıdır.");
            }
            if (entity.DailyPrice < 1)
            {
                return new ErrorResult("Araba Ekleme İşlemi Başarısız. Arabanın Günlük Kiralama Bedeli En Az 1 Olmalıdır.");
            }
            return base.Add(entity);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            try
            {
                return new SuccessDataResult<List<CarDetailDto>>(Messages.GetEntityListedSuccess,dal.GetCarDetails());
            }
            catch (Exception err)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.GetEntityListedError(err.Message));
            }
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(base.service.GetAll(c => c.BrandId == brandId));
            }
            catch (Exception err)
            {
                return new ErrorDataResult<List<Car>>(Messages.GetEntityListedError(err.Message));
            }
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            try
            {
                return new SuccessDataResult<List<Car>>(base.service.GetAll(c => c.ColorId == colorId));
            }
            catch (Exception err)
            {
                return new ErrorDataResult<List<Car>>(Messages.GetEntityListedError(err.Message));
            }
        }

        public override IResult Update(Car entity)
        {
            if (entity.Description.Length <= 2)
            {
                return new ErrorResult("Araba Güncelleme İşlemi Başarısız. Araba Tanımı En Az 3 Karakter Olmalıdır.");
            }
            if (entity.DailyPrice < 1)
            {
                return new ErrorResult("Araba Güncelleme İşlemi Başarısız. Arabanın Günlük Kiralama Bedeli En Az 1 Olmalıdır.");
            }
            return base.Update(entity);
        }
    }
}
