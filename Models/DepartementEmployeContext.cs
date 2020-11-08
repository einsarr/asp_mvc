using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DepartementEmploye.Models
{
    public class DepartementEmployeContext:DbContext
    {
        public DepartementEmployeContext() : base("connexionDB") {  }

        public DbSet<Departement> departements { get; set; }
        public DbSet<Employe> employes { get; set; }

    }
}