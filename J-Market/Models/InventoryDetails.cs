﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace J_Market.Models
{
    public class InventoryDetails
    {
        [Key]
        public int InventoryDetailID { get; set; }

        public int InventoriesID { get; set; }

        public int ID { get; set; }

        [Display(Name = "Descrition")]
        [Required(ErrorMessage = "You must enter {0} ")]
        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} character", MinimumLength = 3)]
        public string Description { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = false)]
        public float Quantity { get; set; }


        // Coneccion Virtuales
        public virtual Inventories Inventories { get; set; }
        public virtual Order Orders { get; set; }
    }
}