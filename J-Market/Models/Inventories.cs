using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace J_Market.Models
{
    public class Inventories
    {
        // OJO
        [Key]
        public int  InventoriesID { get; set; }

        public int OrderID { get; set; }

        public DateTime DateInventories { get; set; }

        // Coneccion Virtuales

        public virtual Order Orders { get; set; }
        public virtual ICollection<InventoryDetails> InventoryDetails { get; set; }


    }
}