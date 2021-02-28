using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Car
            builder.RegisterType<CarManager<EfCarDal, EfCarDal>>().As<ICarService>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            // Color
            builder.RegisterType<ColorManager<EfColorDal>>().As<IColorService>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();
            // Brand
            builder.RegisterType<BrandManager<EfBrandDal>>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            // User
            builder.RegisterType<UserManager<EfUserDal>>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            // Customer
            builder.RegisterType<CustomerManager<EfCustomerDal>>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            // Rental
            builder.RegisterType<RentalManager<EfRentalDal>>().As<IRentalService>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();
        }
    }
}
