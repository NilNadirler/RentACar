using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entegrations.PaymentEntegrartion
{
    public class ZiraatBank
    {
        public bool Pay(string cardNumber, string expMonth, string expYear, string ccv, int transactionId)
        {
            return transactionId % 2 == 0;
        }
        public bool ReturnPay(int transactionId)
        {
            return transactionId % 2 == 0;
        }
    }
}
