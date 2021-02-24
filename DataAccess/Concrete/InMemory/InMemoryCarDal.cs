using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            { 
                new Car{Id=1,Description="Volkswagen Golf 5",DailyPrice=500,ColorId=1/*Gümüş Gri*/,ModelYear="2006",BrandId=1/*Volkswagen*/ },
                new Car{Id=2,Description="Toyot Hybrid",DailyPrice=1500,ColorId=1/*Gümüş Gri*/,ModelYear="2020",BrandId=2/*Toyota*/ },
                new Car{Id=3,Description="Ford Focus",DailyPrice=700,ColorId=2/*Mavi*/,ModelYear="2018",BrandId=3/*Ford*/ },
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(tempCar=>tempCar.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars; 
        }

        public Car GetById(int carId)
        {
            return _cars.First(car=>car.Id == carId);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(tCar=>tCar.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear= car.ModelYear;

        }
    }
}
