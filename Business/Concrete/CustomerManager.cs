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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("Admin,Customer.add","Result")]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.GetCRUDSuccess(_customerDal.GetAll().Count,"Müşteri","Ekleme"));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("Admin,Customer.delete", "Result")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.GetCRUDSuccess(_customerDal.GetAll().Count, "Müşteri", "Silme"));
        }

        [CacheAspect]
        [SecuredOperation("Admin,Customer.list", "DataResult", "ListCustomer")]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(Messages.GetEntityListedSuccess,_customerDal.GetAll());
        }

        [CacheAspect]
        [SecuredOperation("Admin,Customer.getbyid", "DataResult", "Customer")]
        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(Messages.GetEntitySuccess("Müşteri"), _customerDal.Get(c=>c.Id == id));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("Admin,Customer.update", "Result")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.GetCRUDSuccess(_customerDal.GetAll().Count, "Müşteri", "Güncelleme"));
        }
    }
}
