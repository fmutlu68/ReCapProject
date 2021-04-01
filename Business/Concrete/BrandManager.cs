using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("Admin,Brand.add", "Result")]
        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccessResult(Messages.GetCRUDSuccess(_brandDal.GetAll().Count,"Marka","Ekleme"));
        }

        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("Admin,Brand.delete", "Result")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.GetCRUDSuccess(_brandDal.GetAll().Count, "Marka", "Silme"));
        }

        [CacheAspect]
        //[SecuredOperation("Admin,Brand.list", "DataResult","ListBrand")]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(Messages.GetEntityListedSuccess,_brandDal.GetAll());
        }


        [CacheAspect]
        //[SecuredOperation("Admin,Brand.getbyid", "DataResult", "Brand")]
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(Messages.GetEntitySuccess("Markayı"),_brandDal.Get(b=>b.Id == id));
        }

        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("Admin,Brand.update", "Result")]
        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(Messages.GetCRUDSuccess(_brandDal.GetAll().Count, "Marka", "Güncelleme"));
        }
    }
}
