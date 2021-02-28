using Core.Utilities.Results;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static IResult Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                string ErrorMessage = "";
                foreach (var Error in result.Errors)
                {
                    if (Error == result.Errors[result.Errors.Count - 1])
                    {
                        ErrorMessage += string.Format("{0} --- {1} {2}", Error.PropertyName, Error.ErrorCode, Error.ErrorMessage);
                        continue;
                    }
                    ErrorMessage += string.Format("{0} --- {1} {2}   ", Error.PropertyName, Error.ErrorCode, Error.ErrorMessage);
                }
                return new ErrorResult(ErrorMessage);
            }
            return null;
        }
    }
}
