using Business.Constants.ErrorCodes;
using Business.Constants.ErrorMessages;
using Business.Constants.PropertyNames;
using Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId)
                .NotEmpty()
                .WithMessage(ErrorMessages.GetEmptyBrandIdError)
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .OverridePropertyName(PropertyNames.GetCarBrandIdFieldName);
            RuleFor(c => c.ColorId)
                .NotEmpty()
                .WithMessage(ErrorMessages.GetEmptyColorIdError)
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .OverridePropertyName(PropertyNames.GetCarColorIdFieldName);
            RuleFor(c => c.DailyPrice)
                .NotEmpty()
                .WithMessage(ErrorMessages.GetEmptyDailyPriceError)
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .OverridePropertyName(PropertyNames.GetCarDailyPriceFieldName);
            RuleFor(c => c.DailyPrice)
                .GreaterThanOrEqualTo(20)
                .WithMessage(ErrorMessages.GetInsufficientDailyPriceError)
                .WithErrorCode(ErrorCodes.GetInsufficientLengthErrorCode)
                .OverridePropertyName(PropertyNames.GetCarDailyPriceFieldName);
            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage(ErrorMessages.GetEmptyDescriptionError)
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .OverridePropertyName(PropertyNames.GetCarDescriptionFieldName);
            RuleFor(c => c.ModelYear)
                .NotEmpty()
                .WithMessage(ErrorMessages.GetEmptyModelYearError)
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .OverridePropertyName(PropertyNames.GetCarModelYearFieldName);
            RuleFor(c => c.ModelYear)
                .MinimumLength(4)
                .WithMessage(ErrorMessages.GetInvalidModelYearError)
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .OverridePropertyName(PropertyNames.GetCarModelYearFieldName);
        }
    }
}
