using Business.Constants.ErrorCodes;
using Business.Constants.ErrorMessages;
using Business.Constants.PropertyNames;
using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(rental=>rental.CarId)
                .NotEmpty()
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .WithMessage(ErrorMessages.GetEmptyCarIdError)
                .OverridePropertyName(PropertyNames.GetRentalCarIdFieldName);
            RuleFor(rental=>rental.CustomerId)
                .NotEmpty()
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .WithMessage(ErrorMessages.GetEmptyCustomerIdError)
                .OverridePropertyName(PropertyNames.GetRentalCustomerIdFieldName);
            //RuleFor(rental=>rental.RentDate)
            //    .NotEmpty()
            //    .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
            //    .WithMessage(ErrorMessages.GetEmptyRentDateError)
            //    .OverridePropertyName(PropertyNames.GetRentalRentDateFieldName);
            //RuleFor(rental => rental.RentDate)
            //    .GreaterThan(DateTime.Now)
            //    .WithMessage(ErrorMessages.GetInvalidRentDateError)
            //    .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
            //    .OverridePropertyName(PropertyNames.GetRentalReturnDateFieldName);

        }
    }
}
