using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace J_Market.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public DateTime DateOrder { get; set; }

        public int CustomerID { get; set; }

        public OrderStatus OrderStatus { get; set; }


        // Coneccion Virtuales
        [JsonIgnore]
        public virtual Customer Customers { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        
    }
}