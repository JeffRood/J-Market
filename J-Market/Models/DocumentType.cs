using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace J_Market.Models
{
    public class DocumentType
    {
        [Key]
        [Display(Name = "Tipo de Documento")]

        public int DocumentTypeID { get; set; }
        [Display(Name = "Documento")]
        public string Descripcion { get; set; }



        // Coneccion Virtuales
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }


    }
}