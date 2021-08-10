using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
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
    public class CustomerManager: ICustomerService
    {
        ICustomerDal _customerdal;

        public CustomerManager(ICustomerDal customerdal)
        {
            _customerdal = customerdal;
        }

        [ValidationAspect(typeof(CustomerValidation))]
        public IResult Add(Customer customer)
        {
            _customerdal.Add(customer);
            return new SuccessResult(Messages.MusteriAdd);
        }

        public IResult Delete(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Customer>> GetAll()
        {
           return new SuccessDataResult<List<Customer>>(_customerdal.GetAll(),Messages.Urunlist);
        }

        public IDataResult <Customer> GetId(int Id)



        {
            ////var result = _customerdal.GetAll(c => c.Id == Id).Any();
            //if (result==true)
            //{
            //    return new SuccessDataResult<Customer>(_customerdal.GetAll(c => c.Id == Id) ,Messages.MusteriAdd);
            //}

            
            //  return new ErrorDataResult<List<Customer>>(,Messages.MusteriHata);
            return new SuccessDataResult<Customer>(_customerdal.Get (c => c.Id == Id));

        }

        public IDataResult<List<Customer>> GetName(string name)
        {
            return new SuccessDataResult<List<Customer>>(_customerdal.GetAll(c => c.CompanyName.Contains (name)),Messages.Urunlist);
            //if (result.Success)
            //{
            //    Console.WriteLine(Messages.Urunlist);
            //}
            //return new ErrorDataResult<List<Customer>>(default, Messages.MusteriHata);
        }

        public IDataResult<Customer> GetUserId(int userID)
        {
            return new SuccessDataResult<Customer>(_customerdal.Get(c => c.UserId == userID));
        }
        [ValidationAspect(typeof(CustomerValidation))]
        public IResult Update(Customer customer)
        {
            _customerdal.Update(customer);
            return new SuccessResult();
        }

       
    }
}
