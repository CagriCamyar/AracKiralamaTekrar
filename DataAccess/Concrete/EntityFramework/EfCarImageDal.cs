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
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCapProjectContext>, ICarImageDal
    {
        public List<CarImageDetailDto> CarImageDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join ci in context.CarImages
                             on c.CarId equals ci.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarImageDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ImagePath = ci.ImagePath,
                                 Date = ci.Date,
                             };
                return result.ToList();
                  
            }
        }

    }
}
