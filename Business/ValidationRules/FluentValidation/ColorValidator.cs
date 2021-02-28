using Business.Constants.ErrorCodes;
using Business.Constants.ErrorMessages;
using Business.Constants.PropertyNames;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(color=>color.Name)
                .NotEmpty()
                .WithMessage(ErrorMessages.GetEmptyColorNameError)
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .OverridePropertyName(PropertyNames.GetColorColorFieldName);
            RuleFor(color=>color.Name)
                .MinimumLength(2)
                .WithMessage(ErrorMessages.GetMinLengthColorNameError)
                .WithErrorCode(ErrorCodes.GetInsufficientLengthErrorCode)
                .OverridePropertyName(PropertyNames.GetColorColorFieldName);
        }
    }
}
