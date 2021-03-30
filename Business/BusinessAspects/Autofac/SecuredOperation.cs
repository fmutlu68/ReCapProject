using Business.Constants.ErrorMessages;
using Castle.DynamicProxy;
using Core.Entities;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private string _returnType;
        private string _willReturnObjectType;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles,string returnType, string willReturnObjectType = "")
        {
            _roles = roles.Split(',');
            _returnType = returnType;
            _willReturnObjectType = willReturnObjectType;
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        public override void Intercept(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    invocation.Proceed();
                    return;
                }
            }
            if (_returnType == "DataResult")
            {
                if (_willReturnObjectType.Contains("List"))
                {
                    if (_willReturnObjectType.Contains("Car"))
                    {
                        invocation.ReturnValue = new ErrorDataResult<List<Car>>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                    }else if (_willReturnObjectType.Contains("Customer"))
                    {
                        invocation.ReturnValue = new ErrorDataResult<List<Customer>>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                    }else if (_willReturnObjectType.Contains("CarImage"))
                    {
                        invocation.ReturnValue = new ErrorDataResult<List<CarImage>>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                    }
                    else if (_willReturnObjectType.Contains("Brand"))
                    {
                        invocation.ReturnValue = new ErrorDataResult<List<Brand>>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                    }
                    else if (_willReturnObjectType.Contains("Color"))
                    {
                        invocation.ReturnValue = new ErrorDataResult<List<Color>>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                    }
                    else if (_willReturnObjectType.Contains("Rental"))
                    {
                        invocation.ReturnValue = new ErrorDataResult<List<Rental>>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                    }
                    else if (_willReturnObjectType.Contains("User"))
                    {
                        invocation.ReturnValue = new ErrorDataResult<List<User>>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                    }
                    return;
                }
                if (_willReturnObjectType.Contains("Car"))
                {
                    invocation.ReturnValue = new ErrorDataResult<Car>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                }
                else if (_willReturnObjectType.Contains("Customer"))
                {
                    invocation.ReturnValue = new ErrorDataResult<Customer>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                }
                else if (_willReturnObjectType.Contains("CarImage"))
                {
                    invocation.ReturnValue = new ErrorDataResult<CarImage>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                }
                else if (_willReturnObjectType.Contains("Brand"))
                {
                    invocation.ReturnValue = new ErrorDataResult<Brand>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                }
                else if (_willReturnObjectType.Contains("Color"))
                {
                    invocation.ReturnValue = new ErrorDataResult<Color>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                }
                else if (_willReturnObjectType.Contains("Rental"))
                {
                    invocation.ReturnValue = new ErrorDataResult<Rental>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                }
                else if (_willReturnObjectType.Contains("User"))
                {
                    invocation.ReturnValue = new ErrorDataResult<User>(ErrorMessages.GetSecuredOperationNotAuthorizedError);
                }
                return;
            }
            invocation.ReturnValue = new ErrorResult(ErrorMessages.GetSecuredOperationNotAuthorizedError);
            return;
        }
    }
}
