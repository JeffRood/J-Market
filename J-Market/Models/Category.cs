using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace J_Market.Models
{
    public class Category
    {
        [key]
        public int CategoryID { get; set; }

        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} character", MinimumLength = 3)]
        [Display(Name = "Documento")]
        [Required(ErrorMessage = "You must enter {0} ")]
        public string Descripcion { get; set; }

    }
}