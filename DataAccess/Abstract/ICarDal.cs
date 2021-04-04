using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Dtos;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICarDal : IDal<Car>
    {
        List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto,bool>> filter = null);
        CarDetailDto GetCarDetail(Expression<Func<CarDetailDto, bool>> filter);
    }
}
