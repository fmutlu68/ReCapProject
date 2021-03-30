using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System.Collections.Generic;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Caching;
using Business.BusinessAspects.Autofac;
using Core.Constants;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.GetCRUDSuccess(_userDal.GetAll().Count,"Kullanıcı","Ekleme"));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.GetCRUDSuccess(_userDal.GetAll().Count, "Kullanıcı", "Silme"));
        }

        [CacheAspect]
        [SecuredOperation("Admin,User.list", "DataResult", "ListUser")]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(Messages.GetEntityListedSuccess,_userDal.GetAll());
        }

        [CacheAspect]
        [SecuredOperation("Admin,User.getbyid", "DataResult", "User")]
        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(Messages.GetEntitySuccess("Kullanıcı"), _userDal.Get(u=>u.Id == id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            User gotUser = _userDal.Get(user => user.Email == email);
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

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.GetCRUDSuccess(_userDal.GetAll().Count, "Kullanıcı", "Güncelleme"));
        }
    }
}
