﻿using Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
   public class CarDetailDto :IDto
    {
      
  
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
    }

    
}
