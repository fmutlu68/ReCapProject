using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Business.EntityFrameworkBusiness;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager<TDal> : EfBusinessServiceBase<Brand, TDal>, IBrandService
        where TDal : class, IDal<Brand>, new()
    {
        public override IResult Add(Brand entity)
        {
            var result = ValidationTool.Validate(new BrandValidator(),entity);
            return result == null ? base.Add(entity) : result;
        }
        public override IResult Update(Brand entity)
        {
            var result = ValidationTool.Validate(new BrandValidator(),entity);
            return result == null ? base.Update(entity) : result;
        }
    }
}
