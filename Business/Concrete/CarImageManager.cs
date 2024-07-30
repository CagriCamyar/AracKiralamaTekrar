using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
          
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfMaxImageLimitOfCar(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(formFile, PathConstants.ImagesPath);
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == carId), Messages.CarImagesListedByCarId);
        }

        public IDataResult<CarImage> GetByImageId(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(ci => ci.CarImageId == carImageId), Messages.CarImageFound);
        }

        public IDataResult<List<CarImageDetailDto>> GetCarImagesDetail()
        {
            return new SuccessDataResult<List<CarImageDetailDto>>(_carImageDal.CarImageDetails(), Messages.CarImagesListedWithDetails);

        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfMaxImageLimitOfCar(carImage.CarId), DeleteOldImage(carImage.CarImageId, carImage.ImagePath));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Update(formFile, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }


        private IResult CheckIfMaxImageLimitOfCar(int carId)
        {
            var result = _carImageDal.GetAll(ci=> ci.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarImagesOverLimit);
            }
            return new SuccessResult();
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result > 0) return new SuccessResult();
            return new ErrorResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            var carImage = new List<CarImage> { new CarImage { CarId = carId, ImagePath = "DefaultImage.jpg" } };
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
        private IResult DeleteOldImage(int carImageId, string path)
        {
            var result = _carImageDal.Get(ci => ci.CarImageId == carImageId).ImagePath;
            if (File.Exists(path + PathConstants.ImagesPath + result))
            {
                File.Delete(path + PathConstants.ImagesPath + result);
            }
            return new SuccessResult();
        }
    }
}
