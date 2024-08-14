using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetAllCustomerDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 UserId = u.UserId,
                                 CompanyName = cu.CompanyName,
                                 CustomerId = cu.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 PasswordHash = u.PasswordHash,
                                 PasswordSalt = u.PasswordSalt,
                                 Status = u.Status,
                             };
                return result.ToList();
            }
        }       
    }
}
