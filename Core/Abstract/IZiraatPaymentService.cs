using Core.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Core.Abstract
{
    public interface IZiraatPaymentService
    {
        public IDataResult<AddPaymentForTransactionDto> Pay(PaymentDto paymentDto);
        public IResult ReturnPayment(int transactionId);
    }
}
