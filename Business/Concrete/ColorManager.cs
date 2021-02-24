using Business.Abstract;
using Core.Business.EntityFrameworkBusiness;
using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager<TDal> : EfBusinessServiceBase<Color,TDal>,IColorService
        where TDal : class, IDal<Color>, new()
    {
    }
}
