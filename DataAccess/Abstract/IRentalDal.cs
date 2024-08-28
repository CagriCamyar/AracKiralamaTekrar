using Core.DataAccess;
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
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetAllRentalDetails();
        List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>>? filter = null);
        List<RentalDetailDto> CheckRentalCarId(int carId);
        List<Rental> GetRentalCarbyRentReturnDate(int carId, DateTime rentDate, DateTime returnDate);

    }
}
