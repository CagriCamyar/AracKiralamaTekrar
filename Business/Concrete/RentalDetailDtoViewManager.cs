using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalDetailDtoViewManager : IRentalDetailDtoViewService
    {
        IRentalDal _rentalDal;

        public RentalDetailDtoViewManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<RentalDetailDtoView>> GetAllRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDtoView>>(_rentalDal.GetRentalDetailView(), Messages.RentalDetaislListed );
        }
      
    }
}
