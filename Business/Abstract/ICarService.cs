using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        string Add(Car car); // Ekledikten Sonra Bir Mesaj Döndürecek
        string Delete(Car car); //Silindikten Sonra Bir Mesaj Döndürecek
        string Update(Car car); //Güncellendikten Sonra Bir Mesaj Döndürecek
        Car GetById(int carId); 
    }
}
