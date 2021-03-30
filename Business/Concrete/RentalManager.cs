using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin,Rental.add","Result")]
        public IResult Add(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.GetCRUDSuccess(_rentalDal.GetAll().Count,"Kiralama","Ekleme"));
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin,Rental.delete", "Result")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.GetCRUDSuccess(_rentalDal.GetAll().Count, "Kiralama", "Silme"));
        }

        [CacheAspect]
        [SecuredOperation("admin,Rental.list", "DataResult", "ListRental")]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(Messages.GetEntityListedSuccess,_rentalDal.GetAll());
        }

        [CacheAspect]
        [SecuredOperation("admin,Rental.getbyid", "DataResult", "Rental")]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(Messages.GetEntitySuccess("Kiralama"), _rentalDal.Get(r=>r.Id == id));
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [SecuredOperation("admin,Rental.update", "Result")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.GetCRUDSuccess(_rentalDal.GetAll().Count, "Kiralama", "Güncelleme"));
        }
    }
}
