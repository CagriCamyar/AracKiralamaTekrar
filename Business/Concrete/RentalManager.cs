using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public object CarReturned { get; private set; }

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = RulesForAdd(rental);
            if (!result.Success)
            {
                return result;
            } 
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

 
           public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == rentalId), Messages.GetRental);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails(), Messages.RentalDetaislListed);
        }

        public IResult RulesForAdd(Rental rental)
        {
            return BusinessRules.Run(
                CheckRentDateBeforeToday(rental.RentDate),
                CheckReturnDateBeforeRentDate(rental.RentDate, rental.ReturnDate),
                CheckCarReturned(rental),
                CheckIfCarRentedAtALaterDateWhileReturnDateIsNull(rental));

     
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }


        private IResult CheckRentDateBeforeToday(DateTime rentDate) 
        {
            if (rentDate < DateTime.Now.Date)
            {
                return new ErrorResult(Messages.RentalDateCanNotBeforeToday);
            }
            return new SuccessResult(Messages.RentalApplied);
        }
        private IResult CheckIfCarRentedAtALaterDateWhileReturnDateIsNull(Rental rental)
        {
            var result = _rentalDal.Get(r=> r.CarId == rental.CarId && rental.ReturnDate == null && r.RentDate.Date > rental.RentDate.Date);
            if(result != null)
            {
                return new ErrorResult(Messages.RentalRejected);
            }
            return new SuccessResult(Messages.RentalApplied);
        }
        private IResult CheckCarReturned(Rental rental)
        {
            var result = _rentalDal.Get(r=> r.CarId == rental.CarId && r.ReturnDate == null);
            if (result != null)
            {
                return new ErrorResult(Messages.RentalRejected);
            }
            return new SuccessResult(Messages.RentalApplied);
        }
        private IResult CheckReturnDateBeforeRentDate(DateTime rentDate, DateTime? returnDate)
        {
            if (returnDate != null)
            {
                if(returnDate < rentDate)
                {
                    return new ErrorResult(Messages.ReturnDateCanNotBeforeRentDate);
                }
            }
                return new SuccessResult();           
        }

        public IResult IsRentable(int carId)
        {
            var result = _rentalDal.GetAll();
            if (result.Where(r=> r.CarId == carId && r.ReturnDate == null).Any())
            {
                return new ErrorResult(Messages.RentalRejected);
            }
            return new SuccessResult(Messages.RentalApplied);
        }

        public IResult IsCarReturned(int carId)
        {
            var result = _rentalDal.Get(r=> r.CarId==carId && r.ReturnDate == null);
            result.ReturnDate = DateTime.Now;
            _rentalDal.Update(result);
            return new SuccessResult(Messages.CarReturned);
        }

        public IDataResult<List<Rental>> GetRentalCarbyRentReturnDate(int carId, DateTime rentDate, DateTime returnDate)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetRentalCarbyRentReturnDate(carId, rentDate, returnDate));
        }
    }
} 
