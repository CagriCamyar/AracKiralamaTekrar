﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> Get(int carId);
        IDataResult<Car> GetCarByBrandId(int brandId);
        IDataResult<Car> GetCarByColorId(int colorId);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult NameMinTwoChars (Car car);
        IResult DailyPriceMoreThanZero (Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
