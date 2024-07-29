using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;        
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
           ValidationTool.Validate(new CarValidator(), car);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult DailyPriceMoreThanZero(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                _carDal.Add(car);
                return new ErrorResult(Messages.DailyPriceError);
            }
            return new SuccessResult(Messages.CarAdded);

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListedWithDetails);
        }

        public IDataResult<Car> GetCarByBrandId(int brandId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.BrandId == brandId),Messages.GetCarByBrandId);
        }

        public IDataResult<Car> GetCarByColorId(int colorId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ColorId == colorId), Messages.GetCarByColorId);
                
        }

        public IResult NameMinTwoChars(Car car)
        {
            if (car.Description.Length <= 2)
            {
                _carDal.Add(car);
            return new ErrorResult(Messages.CharError);
            }
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Update(Car car)
        {
            var result = _carDal.GetAll(c=> c.BrandId==car.BrandId).Count;
            if (result >= 10) 
            {
                return new ErrorResult(Messages.CarUpdateError);
            }
            return new SuccessResult(Messages.CarUpdated);
                }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<Car> Get(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId==carId), Messages.GetCarId);
        }
    }
}
