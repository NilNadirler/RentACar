﻿
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concentre
{
     public class Car : IEntity
    {
        public int ID { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }

    }
}
