using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentalDetailDto:IDto
    {
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? RentDate { get; set; }

        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }


    }
}
