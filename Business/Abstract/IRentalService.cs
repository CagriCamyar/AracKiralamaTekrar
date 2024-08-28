using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(int rentalId);
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();
        IResult RulesForAdd(Rental rental);
        IResult IsRentable(int carId);
        IResult IsCarReturned(int carId);
        IDataResult<List<Rental>> GetRentalCarbyRentReturnDate(int carId, DateTime rentDate, DateTime returnDate);

    }
}
