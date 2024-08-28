using Entities.Concrete;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Dtos;
using System.Linq.Expressions;
using Core.Entities.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
       
        public List<CarDetailDto> GetAllCarDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join ci in context.CarImages
                             on c.CarId equals ci.CarId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = ci.ImagePath
                             };
                return result.ToList();
            }
        }     
        public List<CarDetailDto> GetAllCarDetailsByBrandId(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join ci in context.CarImages
                             on c.CarId equals ci.CarId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = ci.ImagePath
                             };

                if (filter == null)
                {
                    return result.ToList();
                }
                else
                {
                    result = result.Where(filter);
                    return result.ToList();
                }
            }
        }

        public List<CarDetailDto> GetAllCarDetailsByCarId(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join ci in context.CarImages
                             on c.CarId equals ci.CarId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = cl.ColorId,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = ci.ImagePath
                             };

                if (filter == null)
                {
                    return result.ToList();
                }
                else
                {
                    result = result.Where(filter);
                    return result.ToList();
                }          
            }
        }

        public List<CarDetailDto> GetAllCarDetailsByColorId(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join ci in context.CarImages
                             on c.CarId equals ci.CarId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = cl.ColorId,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 ImagePath = ci.ImagePath
                             };

                if (filter == null)
                {
                    return result.ToList();
                }
                else
                {
                    result = result.Where(filter);
                    return result.ToList();
                }
            }   
        }

        public List<CarDetailDto> GetCarByBrandAndColorId(int brandId, int colorId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             where
                             (brandId > 0 ? c.BrandId == brandId : true)
                             &&
                             (colorId > 0 ? c.ColorId == colorId : true)
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = cl.ColorId,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 CarName = c.CarName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                             };
                return result.ToList();
            }
        }
    }
}
