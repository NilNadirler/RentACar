using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concentre
{
   public class Customer:IEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int UserId { get; set; }
    }
}
