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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        //[SecuredOperation("Admin,Color.add", "Result")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.GetCRUDSuccess(_colorDal.GetAll().Count, "Renk", "Ekleme"));
        }

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        //[SecuredOperation("Admin,Color.delete", "Result")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.GetCRUDSuccess(_colorDal.GetAll().Count, "Renk", "Silme"));
        }

        [CacheAspect]
        //[SecuredOperation("Admin,Color.list","DataResult", "ListColor")]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(Messages.GetEntityListedSuccess,_colorDal.GetAll());
        }

        [CacheAspect]
        //[SecuredOperation("Admin,Color.getbyid", "DataResult", "Color")]
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(Messages.GetEntityListedSuccess, _colorDal.Get(c=>c.Id == id));
        }

        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        [SecuredOperation("Admin,Color.update", "Result")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.GetCRUDSuccess(_colorDal.GetAll().Count, "Renk", "Güncelleme"));
        }
    }
}
