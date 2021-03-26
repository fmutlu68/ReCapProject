using Core.Entities.Concrete;
using Core.Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IDal<User>
    {
        List<OperationClaim> getClaims(User user);
    }
}
