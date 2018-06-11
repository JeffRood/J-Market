using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace J_Market.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }



        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must enter {0} ")]
        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} character", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You must enter {0} ")]
        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} character", MinimumLength = 3)]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Address { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter {0} ")]
        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} character", MinimumLength = 5)]
        public string Document { get; set; }


        public int? DocumentTypeID { get; set; }

      
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName);}}



        // Coneccion Virtuales
        [JsonIgnore]
        public virtual DocumentType DocumentType { get; set; }
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }

    }
}