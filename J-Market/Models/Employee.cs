using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace J_Market.Models
{
    
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        
        [Display(Name ="First Name")]
        [Required(ErrorMessage = "You must enter {0} ")]
        [StringLength(30,ErrorMessage = "The Field {0} must be between {2} and {1} character", MinimumLength = 3)]
        public string FirstName { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must enter {0} ")]
        [StringLength(30, ErrorMessage = "The Field {0} must be between {2} and {1} character", MinimumLength = 3)]
        public string LastName { get; set; }
        [Display(Name = "Salary")]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "You must enter {0} ")]
        public decimal Salary { get; set; }
        [Display(Name = "% de Bonos")]

        [DisplayFormat(DataFormatString = "{0:p2}", ApplyFormatInEditMode = false)]
        public float BonusPercent { get; set; }
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0: yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "You must enter {0} ")]
       
        public DateTime DateofBirth { get; set; }
        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
       
        [Required(ErrorMessage = "You must enter {0} ")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Url)]
        public string URL { get; set; }

        public int DocumentTypeID { get; set; }

        [NotMapped]
        public int Age { get{ return DateTime.Now.Year - DateofBirth.Year ; } }



        // Coneccion Virtuales
        public virtual DocumentType DocumentType { get; set; }
    }
}