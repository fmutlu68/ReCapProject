using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new CustomerDetailDto
                             {
                                 CompanyName = customer.CompanyName,
                                 UserEmail = user.Email,
                                 UserId = user.Id,
                                 UserName = $"{user.FirstName} {user.LastName}",
                                 CustomerId = customer.Id
                             };
                return filter == null ? result.ToList() :  result.Where(filter).ToList();
            }
        }
    }
}
