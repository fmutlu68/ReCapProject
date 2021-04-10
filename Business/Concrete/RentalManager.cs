using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.ErrorCodes;
using Business.Constants.ErrorMessages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICreditCardService _creditCardService;

        public RentalManager(IRentalDal rentalDal, ICreditCardService creditCardService)
        {
            _rentalDal = rentalDal;
            _creditCardService = creditCardService;
        }

        //[ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        //[SecuredOperation("Admin,Rental.add","Result")]
        public IResult RentACar(RentalRentDto rentalRentDto)
        {
            if (CheckIfSelectedCarWasRented(rentalRentDto))
            {
                return new ErrorResult($"{ErrorCodes.GetAlreadyExistRentalOfSelectedCarErrorCode}  {ErrorMessages.GetAlreadyExistRentalOfSelectedCarError}");
            }
            else
            {
                if (_creditCardService.Pay(rentalRentDto.CurrentCreditCard,rentalRentDto.PaymentAmount) == 1)
                {
                    _rentalDal.Add(rentalRentDto.CurrentRental);
                    return new SuccessResult(Messages.GetCRUDSuccess(_rentalDal.GetAll().Count, "Kiralama", "Kiralama"));
                }
                else
                {
                    return new ErrorResult(ErrorMessages.GetNoPaymentFromCreditCardError);
                }
            }
            
        }

        private bool CheckIfSelectedCarWasRented(RentalRentDto selectedRental)
        {
            var rentals = _rentalDal.GetAll(r=>r.CarId == selectedRental.CurrentRental.CarId);
            foreach (Rental rental in rentals)
            {   
                if (rental.ReturnDate.Date >= selectedRental.CurrentRental.RentDate.Date)
                {
                    return true;
                }
            }
            return false;
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
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(Messages.GetEntityListedSuccess,_rentalDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(Messages.GetEntityListedSuccess, _rentalDal.GetRentalDetails());
        }

        [CacheAspect]
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
