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
    public class ColorManager<TDal> : EfBusinessServiceBase<Color,TDal>,IColorService
        where TDal : class, IDal<Color>, new()
    {
        public override IResult Add(Color entity)
        {
            var result = ValidationTool.Validate(new ColorValidator(), entity);
            return result == null ? base.Add(entity) : result;
        }
        public override IResult Update(Color entity)
        {
            var result = ValidationTool.Validate(new ColorValidator(), entity);
            return result == null ? base.Update(entity) : result;
        }
    }
}
