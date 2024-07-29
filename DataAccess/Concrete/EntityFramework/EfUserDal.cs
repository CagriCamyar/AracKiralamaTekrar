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
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {
        public List<UserDetailDto> GetUserDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from cu in context.Customers
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new UserDetailDto
                             {
                                 UserId = u.UserId,
                                 CompanyName = cu.CompanyName,
                                 CustomerId = cu.CustomerId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 Password = u.Password,
                             };
                return result.ToList();
            }
        }
    }
}
