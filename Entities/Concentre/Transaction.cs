using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concentre
{
    public class Transaction:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? UserId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal DailyPrice { get; set; }
        public int PayIn { get; set; }
        public string CardOfBank { get; set; }
        public string CardHolderName { get; set; }
        public string CardMaskedNumber { get; set; }
        public string TransactionIdOfBank { get; set; }
        public string Description { get; set; }
    }
}
