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
    public class CarDetailDtoManager : ICarDetailDtoService
    {
        ICarDal _carDal;

        public CarDetailDtoManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IDataResult<List<CarDetailDto>> GetAllCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetailsListed);
        }
    }
}
