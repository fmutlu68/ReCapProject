using Business.Constants.ErrorCodes;
using Business.Constants.ErrorMessages;
using Business.Constants.PropertyNames;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email)
                .NotEmpty()
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .WithMessage(ErrorMessages.GetEmptyEmailError)
                .OverridePropertyName(PropertyNames.GetUserEmailFieldName);
            RuleFor(user => user.Email)
                .EmailAddress()
                .WithMessage(ErrorMessages.GetInvalidEmailError)
                .WithErrorCode(ErrorCodes.GetInvalidEmailErrorCode)
                .OverridePropertyName(PropertyNames.GetUserEmailFieldName);
            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .OverridePropertyName(PropertyNames.GetUserFirstNameFieldName)
                .WithMessage(ErrorMessages.GetEmptyFirstNameError);
            RuleFor(user => user.FirstName)
                .MinimumLength(2)
                .WithErrorCode(ErrorCodes.GetInsufficientLengthErrorCode)
                .OverridePropertyName(PropertyNames.GetUserFirstNameFieldName)
                .WithMessage(ErrorMessages.GetMinLengthFirstNameError);
            RuleFor(user => user.LastName)
                .NotEmpty()
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .OverridePropertyName(PropertyNames.GetUserLastNameFieldName)
                .WithMessage(ErrorMessages.GetEmptyLastNameError);
            RuleFor(user => user.LastName)
                .MinimumLength(2)
                .WithErrorCode(ErrorCodes.GetInsufficientLengthErrorCode)
                .OverridePropertyName(PropertyNames.GetUserLastNameFieldName)
                .WithMessage(ErrorMessages.GetMinLengthLastNameError);
            //RuleFor(user => user.Password)
            //    .NotEmpty()
            ////    .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
            //    .OverridePropertyName(PropertyNames.GetUserPasswordFieldName)
            //    .WithMessage(ErrorMessages.GetEmptyPasswordError);
            //RuleFor(user => user.Password)
            //    .MinimumLength(8)
            //    .WithErrorCode(ErrorCodes.GetInsufficientLengthErrorCode)
            //    .OverridePropertyName(PropertyNames.GetUserPasswordFieldName)
            //    .WithMessage(ErrorMessages.GetMinLengthPasswordError);
        }

    }
}
