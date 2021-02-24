using Business.Abstract;
using Core.Business.EntityFrameworkBusiness;
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
            if (entity.RentDate == DateTime.MinValue)
            {
                return new ErrorResult("Bir Kiralama İşleminin Yapılabilmesi İçin Kiralama Tarihinin Girilmesi Gerekmektedir.");
            }
            return base.Add(entity);
        }
    }
}
