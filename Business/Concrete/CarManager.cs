using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public string Add(Car car)
        {
            try
            {
                _carDal.Add(car);
                return "Araba Ekleme İşlemi Başarılı. Toplam Araba Sayısı: " + _carDal.GetAll().Count.ToString();
            }
            catch (Exception e)
            {
                return "Bir Hata oluştu: " + e.Message.ToString();
            }
        }

        public string Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                return "Araba Silme İşlemi Başarılı. Toplam Araba Sayısı: " + _carDal.GetAll().Count.ToString();
            }
            catch (Exception e)
            {
                return "Bir Hata oluştu: " + e.Message.ToString();
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int carId)
        {
            return _carDal.GetById(carId);
        }

        public string Update(Car car)
        {

            try
            {
                _carDal.Update(car);
                return "Araba Güncelleme İşlemi Başarılı. Toplam Araba Sayısı: " + _carDal.GetAll().Count.ToString();
            }
            catch (Exception e)
            {
                return "Bir Hata oluştu: " + e.Message.ToString();
            }
        }
    }
}
