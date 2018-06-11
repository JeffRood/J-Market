using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace J_Market.Models
{
    public class Product
    {

        [Key]
        public int ID { get; set; }
        [Display(Name = "Descrition")]
        public string Description { get; set; }
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }
        [Display(Name = "Stock")]
        public float Stock { get; set; }

        [Display(Name = "Last Buy")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime LastBuy { get; set; }
        [Display(Name = "Remarks")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }


        // Coneccion Virtuales
        [JsonIgnore]
         public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
       
    }
}