using Business.Constants.ErrorCodes;
using Business.Constants.ErrorMessages;
using Business.Constants.PropertyNames;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(brand => brand.Name)
                .NotEmpty()
                .WithMessage(ErrorMessages.GetEmptyBrandNameError)
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .OverridePropertyName(PropertyNames.GetBrandBrandFieldName);
            RuleFor(brand => brand.Name)
                .MinimumLength(2)
                .WithMessage(ErrorMessages.GetMinLengthBrandNameError)
                .WithErrorCode(ErrorCodes.GetInsufficientLengthErrorCode)
                .OverridePropertyName(PropertyNames.GetBrandBrandFieldName);
        }
    }
}
