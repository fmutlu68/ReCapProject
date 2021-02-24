using Business.Abstract;
using Core.Business.EntityFrameworkBusiness;
using Core.Entities;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager<TDal> : EfBusinessServiceBase<Customer, TDal>, ICustomerService
        where TDal : class, IDal<Customer>, new()
    {
    }
}
