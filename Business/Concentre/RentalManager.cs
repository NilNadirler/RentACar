using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concentre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concentre
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentaldal;

        public RentalManager(IRentalDal rentaldal)
        {
            _rentaldal = rentaldal;
        }


        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = _rentaldal.GetAll(r => r.CarId == rental.CarId && (r.ReturnDate == null || r.ReturnDate > DateTime.Now)).Any();
            if (result == true)
            {
                return new ErrorResult();
            }
            else
            {
                _rentaldal.Add(rental);
                return new SuccessResult();
            }

        }

        public IResult Delete(Rental rental)
        {
            _rentaldal.Delete(rental);
            return new SuccessResult();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(), Messages.Urunlist);
        }

        public IDataResult<Rental> GetbyCustomerId(int customerID)
        {
            return new SuccessDataResult<Rental>(_rentaldal.Get(r => r.CustomerId == customerID));
        }

        public IDataResult<List<Rental>> RentandReturn(DateTime rentdate, DateTime returndate)
        {

            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(r => r.RentDate >= rentdate && r.ReturnDate <= returndate));

        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentaldal.Update(rental);
            return new SuccessResult();
        }
    
    }



       

    }
    