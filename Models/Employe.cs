using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DepartementEmploye.Models
{
    public class Employe
    {
        [Key]
        public int Eid { get; set; }
        [Display(Name = "Nom"), Required(ErrorMessage = "*"), MaxLength(30, ErrorMessage = "Le maximum de caractères autorisé est 30")]
        public string EName { get; set; }
        [Display(Name = "Salaire"), Required(ErrorMessage = "*")]
        public double ESalary { get; set; }
        [Display(Name = "Sexe"), Required(ErrorMessage = "*")]
        public string EGender { get; set; }
        [Display(Name = "EDOB"), Required(ErrorMessage = "*")]
        public string EDOB { get; set; }
        [Display(Name = "Département"), Required(ErrorMessage = "*")]
        public int Did { get; set; }
        [ForeignKey("Did")]
        public virtual Departement Departement { get; set; }
        [Display(Name = "Date de mise à jour"), Required(ErrorMessage = "*")]
        public string UpdateDate { get; set; }
    }
}