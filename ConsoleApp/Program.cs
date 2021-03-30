using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICarService carService = new CarManager<EfCarDal, EfCarDal>();
            //IColorService colorService = new ColorManager<EfColorDal>();
            //IBrandService brandService = new BrandManager<EfBrandDal>();
            //IUserService userService = new UserManager<EfUserDal>();
            //ICustomerService customerService = new CustomerManager<EfCustomerDal>();
            //IRentalService rentalService = new RentalManager<EfRentalDal>();
            //Console.WriteLine("Kullanıcı Ekleniyor..");
            //Console.WriteLine(userService.Add(new User() { Email="Deneme@gmail.com",FirstName="Deneme", LastName="Test", Password="123456"}).Message);
            //Console.WriteLine("Müşteri Ekleniyor..");
            //Console.WriteLine(customerService.Add(new Customer() { UserId=1}).Message);
            //Console.WriteLine(rentalService.Add(new Rental() { }).Message);
        }
    }
}
