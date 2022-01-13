using Core.Abstract;
using Core.Entities.Concrete;
using Core.Result;
using Core.Utilities.Results;
using Entegrations.PaymentEntegrartion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrete
{
    public class ZiraatPaymentAdapter : IZiraatPaymentService
    {
        public IDataResult<AddPaymentForTransactionDto> Pay(PaymentDto paymentDto)
        {
            Random rnd = new Random();
            int transactionId = rnd.Next(0,Int32.MaxValue);
            ZiraatBank ziraatbank = new ZiraatBank();
            if (ziraatbank.Pay(paymentDto.CardMaskedNumber, paymentDto.CardExpireMonth, paymentDto.CardExpireYear,paymentDto.CCV,paymentDto.Id))
            {
                var result= new AddPaymentForTransactionDto() { 
                    Id=paymentDto.Id,
                    CardHolderName=paymentDto.CardHolderName,
                    CardMaskedNumber=paymentDto.CardMaskedNumber,
                    CardOfBank="Ziraat",
                    PayIn=paymentDto.PayIn,
                    TransactionIdOfBank= transactionId.ToString()
                };
                return new SuccessDataResult<AddPaymentForTransactionDto>(result,"Ödeme başarılı");
            }
            return new ErrorDataResult<AddPaymentForTransactionDto>(null,"Ödeme başarısız.");
        }

        public IResult ReturnPayment(int transactionId)
        {
            ZiraatBank ziraatbank = new ZiraatBank();
            if (ziraatbank.ReturnPay(transactionId))
            {
                return new SuccessResult("İade başarılı.");
            }
            return new ErrorResult("İade başarısız.");
        }
    }
}
