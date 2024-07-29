using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult("Kiralama Basarili");
        }

        public IResult DailyPriceMoreThanZero(Car car)
        {
            if (car.DailyPrice <= 0)
            {
                _carDal.Add(car);
                return new ErrorResult("Aracin Fiyati 0 dan buyuk olmalidir");
            }
            return new SuccessResult("Arac Eklendi");

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), "Araclar Listelendi");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), "Arac Detaylari Listelendi");
        }

        public IDataResult<Car> GetCarByBrandId(int brandId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.BrandId == brandId),"Sectiginiz Markadanin Araclari :" );
        }

        public IDataResult<Car> GetCarByColorId(int colorId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.ColorId == colorId), "Sectiginiz Rengin Araclari : ");
                
        }

        public IResult NameMinTwoChars(Car car)
        {
            if (car.Description.Length <= 2)
            {
                _carDal.Add(car);
            return new ErrorResult("Arac Ismi Minimum 3 Karakterden Olusmalidir");
            }
            return new SuccessResult("Arac Eklendi");

        }

        public IResult Update(Car car)
        {
            var result = _carDal.GetAll(c=> c.BrandId==car.BrandId).Count;
            if (result >= 10) 
            {
                return new ErrorResult("Guncelleme Basarisiz");
            }
            return new SuccessResult("Arac Bilgileri Guncellendi");
                }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Arac Silindi");
        }

        public IDataResult<Car> Get(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c=>c.CarId==carId), "Sectiginiz Arac : ");
        }
    }
}
