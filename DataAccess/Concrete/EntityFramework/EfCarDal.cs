using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Core.DataAccess.EntityFramework;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public CarDetailDto GetCarDetail(Expression<Func<CarDetailDto, bool>> filter)
        {
            using (CarContext context = new CarContext())
            {
                IQueryable<CarDetailDto> matchingCars = from c in context.Cars
                                   join color in context.Colors
                                   on c.ColorId equals color.Id
                                   join brand in context.Brands
                                   on c.BrandId equals brand.Id
                                   join image in context.CarImages
                                   on c.Id equals image.CarId
                                   select new CarDetailDto
                                   {
                                       CarId = c.Id,
                                       BrandId = brand.Id,
                                       ColorId = color.Id,
                                       BrandName = brand.Name,
                                       ColorName = color.Name,
                                       ModelYear = c.ModelYear,
                                       CarName = c.Description,
                                       DailyPrice = c.DailyPrice
                                   };
                CarDetailDto car = matchingCars.FirstOrDefault(filter);
                if (car == null)
                {
                    car = GetCarDetails().FirstOrDefault(filter.Compile());
                }
                else
                {
                    car.ImageList = context.CarImages.ToList().Where(img => img.CarId == car.CarId).Select(img => img.ImagePath).ToList();
                }
                var allRentalsOfCurrentCar = context.Rentals.Where(r => r.CarId == car.CarId).ToList();
                if (allRentalsOfCurrentCar.Count > 0)
                {
                    car.IsRentedNow = true;
                }
                foreach (Rental rental in allRentalsOfCurrentCar)
                {
                    if (rental.ReturnDate == DateTime.MinValue || rental.ReturnDate > DateTime.Now)
                    {   
                        car.IsRentedNow = true;
                    }
                }
                return car;
            }
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                Console.WriteLine(context.CarImages.Where(c => c.CarId == c.Id).Select(c => c.ImagePath).ToList());
                var result = from c in context.Cars
                             join r in context.Colors
                             on c.ColorId equals r.Id
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             select new CarDetailDto {
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 CarName = c.Description,
                                 ColorName = r.Name,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 BrandId = c.BrandId,
                                 ColorId = c.ColorId,
                             };
                return filter == null ?  result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
