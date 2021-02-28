using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Business.EntityFrameworkBusiness;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager<TDal> : EfBusinessServiceBase<Customer, TDal>, ICustomerService
        where TDal : class, IDal<Customer>, new()
    {
        public override IResult Add(Customer entity)
        {
            var result = ValidationTool.Validate(new CustomerValidator(), entity);
            return result == null ? base.Add(entity) : result;
        }
        public override IResult Update(Customer entity)
        {
            var result = ValidationTool.Validate(new CustomerValidator(), entity);
            return result == null ? base.Update(entity) : result;
        }
    }
}
