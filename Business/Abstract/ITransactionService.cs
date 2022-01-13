using Core.Entities.Concrete;
using Core.Result;
using Entities.Concentre;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ITransactionService
    {
        IDataResult<List<Transaction>> GetAll();
        IDataResult<Transaction> GetById(int id);
        IDataResult<List<Transaction>> GetAllActiveList();
        IDataResult<List<Transaction>> GetByCustomerId(int customerId);
        IDataResult<List<Transaction>> GetByUserId(int userId);
        IResult Add(TransactionDto dto);
        IResult AddPaymentWithTransaction(AddPaymentForTransactionDto addPaymentForTransactionDto);
        IResult EndTransactionById(int transactionId);

    }
}
