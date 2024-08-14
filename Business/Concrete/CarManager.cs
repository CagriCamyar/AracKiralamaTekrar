using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
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
using System.Transactions;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        //[CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfBrandCorrect(car.BrandId),
                CheckIfCarFullNameExist(car.Description), CheckIfBrandLimitExceded());

            if (result != null)
            {
                return result;
            }
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

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(), Messages.CarsListedWithDetails);
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
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Car car)
        {
            var result = _carDal.GetAll(c => c.BrandId == car.BrandId).Count;
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

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> Get(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId), Messages.GetCarId);
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarFullNameExist(string description)
        {
            var result = _carDal.GetAll(c => c.Description == description).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarDescriptionAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count > 20)
            {
                return new ErrorResult(Messages.BrandLimitExceded);
            }
            return new SuccessResult();

        }

        [TransactionScopeAspect]
        public IResult AddTansactionalTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 500)
            {
                throw new Exception("");
            }
            Add(car);
            return null;

        }

        public IDataResult<List<Car>> GetAllCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == brandId), Messages.CarsListedWhichBrand);
        }
        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetailsByCarId(c => c.CarId== carId), Messages.CarDetailsListed);
        }
        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetailsByBrandId(b => b.BrandId == brandId), Messages.CarDetailsListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetailsByColorId(cl => cl.ColorId == colorId), Messages.CarDetailsListed);
        }

      
    }
}