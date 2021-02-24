using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarContext context = new CarContext())
            {
                var result = from c in context.Cars
                             join r in context.Colors
                             on c.ColorId equals r.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto { BrandName = b.Name, CarName = c.Description, ColorName = r.Name, DailyPrice = c.DailyPrice };
                return result.ToList();

            }
        }
    }
}
