using Business.Abstract;
using Core.Business.EntityFrameworkBusiness;
using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager<TDal> : EfBusinessServiceBase<Brand, TDal>, IBrandService
        where TDal : class, IDal<Brand>, new()
    {
    }
}
