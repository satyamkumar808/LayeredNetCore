﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared.ViewModels
{
    public class ProductModel
    {
        public int ModelNum { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int DeliveryTime { get; set; }
    }
}