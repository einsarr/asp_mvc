using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartementEmploye.Models
{
    [Table("tbl_Dept")]
    public class Departement
    {
        [Key]
        public int Did { get; set; }
        [Display(Name ="Nom département"),Required(ErrorMessage ="*"),MaxLength(30,ErrorMessage ="Le maximum de caractères autorisé est 30")]
        public string DName { get; set; }
        [Display(Name = "HOD département"), Required(ErrorMessage = "*"), MaxLength(20, ErrorMessage = "Le maximum de caractères autorisé est 20")]
        public string HOD { get; set; }
        [Display(Name = "Description"), Required(ErrorMessage = "*"), MaxLength(50, ErrorMessage = "Le maximum de caractères autorisé est 50")]
        public string Description { get; set; }

        public virtual List<Employe> Employes { get; set; }
    }
}