using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Business.EntityFrameworkBusiness;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager<TDal> : EfBusinessServiceBase<User, TDal>, IUserService
        where TDal : class, IDal<User>,IUserDal, new()
    {
        TDal _userDal;

        public UserManager()
        {
            _userDal = new TDal();
        }

        public override IResult Add(User entity)
        {
            var result = ValidationTool.Validate(new UserValidator(), entity);
            return result == null ? base.Add(entity) : result;
        }

        public IDataResult<User> GetByMail(string email)
        {
            User gotUser = base.service.Get(user => user.Email == email);
            if (gotUser != null)
            {
                return new SuccessDataResult<User>(gotUser);
            }
            return new ErrorDataResult<User>("Aranılan Kullanıcı Bulunamadı.");
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            List<OperationClaim> gotClaims = _userDal.getClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(gotClaims);
        }

        public override IResult Update(User entity)
        {
            var result = ValidationTool.Validate(new UserValidator(), entity);
            return result == null ? base.Update(entity) : result;
        }
    }
}
