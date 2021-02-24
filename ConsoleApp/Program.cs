using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarManager(new InMemoryCarDal());
            Console.WriteLine("Araç Kiralama Sistemine Hoşgeldiniz.\nBir İşlem Seçiniz.");
            Console.WriteLine("1.Araçları Listele\n2.Araç Ekle\n3.Araç Sil\n4.Araç Güncelle\n5.Çıkış");
            int choosing = int.Parse(Console.ReadLine());
            while (choosing != 5)
            {
                if (choosing == 1)
                {
                    foreach (Car car in carService.GetAll())
                    {
                        Console.WriteLine("Araba İsmi: " + car.Description + " " +car.DailyPrice.ToString() + "\n");     

                    }
                }
                if (choosing == 2)
                {
                    Console.WriteLine("Araç Tanımı: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("Araç Modeli: ");
                    string modelYear = Console.ReadLine();
                    Console.WriteLine("Günlük Kiralama Bedeli: ");
                    double dailyPrice = double.Parse(Console.ReadLine());
                    Console.WriteLine(carService.Add(new Car {Description=description,ModelYear=modelYear,DailyPrice=dailyPrice }));
                }

                Console.WriteLine("\n1.Araçları Listele\n2.Araç Ekle\n3.Araç Sil\n4.Araç Güncelle\n5.Çıkış");
                choosing = int.Parse(Console.ReadLine());
            }
        }
    }
}
