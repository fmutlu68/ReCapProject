using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Business.EntityFrameworkBusiness;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager<TDal> : EfBusinessServiceBase<User, TDal>, IUserService
        where TDal : class, IDal<User>, new()
    {
        public override IResult Add(User entity)
        {
            var result = ValidationTool.Validate(new UserValidator(), entity);
            return result == null ? base.Add(entity) : result;
        }
        public override IResult Update(User entity)
        {
            var result = ValidationTool.Validate(new UserValidator(), entity);
            return result == null ? base.Update(entity) : result;
        }
    }
}
