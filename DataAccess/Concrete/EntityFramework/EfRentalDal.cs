using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>,  IRentalDal
    {
        public List<RentalDetailDto> CheckRentalCarId(int carId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = c.CarId,
                                 CustomerId = cu.CustomerId,
                                 BrandName = b.BrandName,
                                 CarName = c.CarName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };
                return result.ToList();
            }
        }
    

        public List<RentalDetailDto> GetAllRentalDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = c.CarId,
                                 CustomerId = cu.CustomerId,
                                 BrandName = b.BrandName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate= (DateTime)r.ReturnDate
                              };
                return result.ToList();
            }
        }

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>>? filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands 
                             on c.CarId equals b.BrandId
                             join r in context.Rentals 
                             on c.CarId equals r.CarId
                             join cl in context.Colors 
                             on c.ColorId equals cl.ColorId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join u in context.Users 
                             on cu.UserId equals u.UserId

                             select new RentalDetailDto
                             {
                                 BrandName = b.BrandName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CarId = c.CarId,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate,
                                 ColorName = cl.ColorName,
                                 Description = c.Description,
                             };

                if (filter == null)
                {
                    return result.ToList();
                }
                else
                {
                    return result.Where(filter).ToList();
                }

            }
        }

        public List<Rental> GetRentalCarbyRentReturnDate(int carId, DateTime rentDate, DateTime returnDate)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from r in context.Rentals
                             where r.CarId == carId && ((rentDate >= r.RentDate && rentDate <= r.ReturnDate) || (returnDate >= r.RentDate && returnDate <= r.ReturnDate))
                             select new Rental
                             {
                                 RentalId = r.RentalId,
                                 CarId = r.CarId,
                                 RentDate = (DateTime)r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };

                return result.ToList();
            }
        }

    }
}
