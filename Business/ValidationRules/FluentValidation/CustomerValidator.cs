using Business.Constants.ErrorCodes;
using Business.Constants.ErrorMessages;
using Business.Constants.PropertyNames;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c=>c.UserId)
                .NotEmpty()
                .WithMessage(ErrorMessages.GetEmptyCustomerIdError)
                .WithErrorCode(ErrorCodes.GetEmptyFieldErrorCode)
                .OverridePropertyName(PropertyNames.GetCustomerUserIdFieldName);
        }
    }
}
