using Business.Abstract;
using Core.Business.EntityFrameworkBusiness;
using Core.Entities;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager<TDal> : EfBusinessServiceBase<User, TDal>, IUserService
        where TDal : class, IDal<User>, new()
    {
    }
}
