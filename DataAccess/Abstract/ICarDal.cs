using Core.DataAccess;
using Core.Entities.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
         List<CarDetailDto> GetAllCarDetails();
         List<CarDetailDto> GetAllCarDetailsByCarId(Expression<Func<CarDetailDto, bool>> filter = null);
         List<CarDetailDto> GetAllCarDetailsByBrandId(Expression<Func<CarDetailDto, bool>> filter = null);
         List<CarDetailDto> GetAllCarDetailsByColorId(Expression<Func<CarDetailDto, bool>> filter = null);

    }
}