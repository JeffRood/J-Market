﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace J_Market.Models
{
    public class ProductOrder : Product
    {
             [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        public float Quantity { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = false)]
        public decimal Value  { get { return Price * (decimal)Quantity; } }
    }
}