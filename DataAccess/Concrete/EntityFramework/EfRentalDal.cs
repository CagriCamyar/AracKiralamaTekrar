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
       
        public List<RentalDetailDtoView> GetRentalDetailView()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.CarId equals r.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             select new RentalDetailDtoView
                             {
                                 RentalId = r.RentalId,
                                 BrandName = b.BrandName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                             };
                             return result.ToList();

            }
        }

        public List<RentalDetailDto> GetRentalsDetail()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join r in context.Rentals
                             on c.CarId equals r.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             select new RentalDetailDto 
                             {
                                 RentalId = r.RentalId,
                                 CarId = c.CarId,
                                 CustomerId = cu.CustomerId,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate,
                             };
                return result.ToList();
            }
        }

 
    }
}
