using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DepartementEmploye.Models;
using PagedList;

namespace DepartementEmploye.Controllers
{
    public class EmployesController : Controller
    {
        private DepartementEmployeContext db = new DepartementEmployeContext();
        int pageSize = 1;
        // GET: Employes
        public ActionResult Index(int? page, int? Departement, string Nom, double? Salaire)
        {
            page = page.HasValue ? page : 1;
            ViewBag.Departements = db.departements.ToList();
            ViewBag.Departement = Departement != null ? Departement : (int?)null;
            ViewBag.Nom = !string.IsNullOrEmpty(Nom) ? Nom : string.Empty;
            ViewBag.Salaire = Salaire != null ? Salaire : (double?)null;

            var employes = db.employes.Include(e => e.Departement);
            if(Departement != null)
            {
                employes = employes.Where(a => a.Did == Departement);
            }
            if(!string.IsNullOrEmpty(Nom))
            {
                employes = employes.Where(a => a.EName.ToUpper().Contains(Nom.ToUpper()));
            }
            if(Salaire != null)
            {
                employes = employes.Where(a => a.ESalary == Salaire);
            }

            return View(employes.ToList().ToPagedList((int)page, pageSize));
        }

        // GET: Employes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = db.employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // GET: Employes/Create
        public ActionResult Create()
        {
            ViewBag.Did = db.departements.ToList();
            ViewBag.sexePers = listgenre();
            //ViewBag.Did = new SelectList(db.departements, "Did", "DName");
            return View();
        }

        public List<SelectListItem> listgenre()
        {
            List<SelectListItem> liste = new List<SelectListItem>();
            SelectListItem l = new SelectListItem { Text = "Féminin", Value = "F" };
            liste.Add(l);
            l = new SelectListItem { Text = "Masculin", Value = "M" };
            liste.Add(l);
            
            return liste;
        }

        // POST: Employes/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Eid,EName,ESalary,EGender,EDOB,Did,UpdateDate")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                db.employes.Add(employe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sexePers = listgenre();
            ViewBag.Did = db.departements.ToList();
            return View(employe);
        }

        // GET: Employes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = db.employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            ViewBag.Did = new SelectList(db.departements, "Did", "DName", employe.Did);
            return View(employe);
        }

        // POST: Employes/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Eid,EName,ESalary,EGender,EDOB,Did,UpdateDate")] Employe employe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Did = new SelectList(db.departements, "Did", "DName", employe.Did);
            return View(employe);
        }

        // GET: Employes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employe employe = db.employes.Find(id);
            if (employe == null)
            {
                return HttpNotFound();
            }
            return View(employe);
        }

        // POST: Employes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employe employe = db.employes.Find(id);
            db.employes.Remove(employe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
