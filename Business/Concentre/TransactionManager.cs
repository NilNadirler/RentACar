using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concentre;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concentre
{
    public class TransactionManager : ITransactionService
    {
        ITransactionDal _transactionDal;
        ICarDal _carDal;

        public TransactionManager(ITransactionDal transactionDal,ICarDal carDal)
        {
            _transactionDal = transactionDal;
            _carDal = carDal;
        }

        [ValidationAspect(typeof(TransactionValidator))]
        public IResult Add(TransactionDto dto)
        {
            var car=_carDal.GetById(dto.CarId);
            var transaction = new Transaction()
            {
                BrandName = car.BrandName,
                DailyPrice = car.DailyPrice,
                ColorName = car.ColorName,
                CustomerId = dto.CustomerId,
                UserId = dto.UserId,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate

            };
            _transactionDal.Add(transaction);
            return new SuccessResult("Transaction is created");
        }
        public IResult AddPaymentWithTransaction(AddPaymentForTransactionDto addPaymentForTransactionDto)
        {
            var transaction = new Transaction();
            transaction.Id = addPaymentForTransactionDto.Id;
            transaction.PayIn = addPaymentForTransactionDto.PayIn;
            transaction.CardOfBank = addPaymentForTransactionDto.CardOfBank;
            transaction.CardHolderName = addPaymentForTransactionDto.CardHolderName;
            transaction.CardMaskedNumber = addPaymentForTransactionDto.CardMaskedNumber;
            transaction.TransactionIdOfBank = addPaymentForTransactionDto.TransactionIdOfBank;
            _transactionDal.Update(transaction);
            return new SuccessResult("Transaction is updated");
        }

        public IResult EndTransactionById(int transactionId)
        {
            var transaction = new Transaction();
            transaction.Id = transactionId;
            transaction.EndDate = DateTime.Now;
            _transactionDal.Update(transaction);
            return new SuccessResult("Transaction is ended");
        }

        public IDataResult<List<Transaction>> GetAll()
        {
            return new SuccessDataResult<List<Transaction>>(_transactionDal.GetAll(),"All transaction listed.");
        }

        public IDataResult<List<Transaction>> GetAllActiveList()
        {
            return new SuccessDataResult<List<Transaction>>(_transactionDal.GetAll(item=>item.EndDate==null), "All active transaction listed.");
        }

        public IDataResult<List<Transaction>> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Transaction>>(_transactionDal.GetAll(item => item.CustomerId == customerId), "All transaction listed by customer.");
        }

        public IDataResult<Transaction> GetById(int id)
        {
            return new SuccessDataResult<Transaction>(_transactionDal.Get(item => item.Id == id), "Transaction got by filter.");
        }

        public IDataResult<List<Transaction>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Transaction>>(_transactionDal.GetAll(item => item.UserId == userId), "All transaction listed by person.");
        }
    }
}
