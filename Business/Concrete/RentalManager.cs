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
    public class RentalManager<TDal> : EfBusinessServiceBase<Rental, TDal>,IRentalService
        where TDal : class, IDal<Rental>, new()
    {
        public override IResult Add(Rental entity)
        {
            var result = ValidationTool.Validate(new RentalValidator(), entity);
            return result == null ? base.Add(entity) : result;
        }
        public override IResult Update(Rental entity)
        {
            var result = ValidationTool.Validate(new RentalValidator(), entity);
            return result == null ? base.Update(entity) : result;
        }
    }
}
