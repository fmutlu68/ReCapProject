using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    public interface ICarDal : IDal<Car>
    {
        List<CarDetailDto> GetCarDetails();
    }
}
