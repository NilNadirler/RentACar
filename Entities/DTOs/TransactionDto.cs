using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TransactionDto
    {
        public int CustomerId { get; set; }
        public int? UserId { get; set; }
        public int CarId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PayIn { get; set; }
        public string Description { get; set; }
    }
}
