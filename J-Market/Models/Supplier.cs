using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace J_Market.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }


        public string Name { get; set; }

        [Display(Name = "Contact First Name")]
        public string ContactFirstName { get; set; }

        [Display(Name = "Contact Last Name")]
        public string ContacLastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Coneccion Virtuales
        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
    }

}