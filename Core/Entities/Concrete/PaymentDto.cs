using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{

    public class PaymentDto : IDto
    {
        public int Id { get; set; }
        public string CardHolderName { get; set; }
        public string CardMaskedNumber { get; set; }
        public string CardExpireMonth { get; set; }
        public string CardExpireYear { get; set; }
        public string CCV { get; set; }
        public int PayIn { get; set; }
    }
}
