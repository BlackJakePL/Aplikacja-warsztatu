using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Warsztat_programowanie_obiektowe.Models;

namespace Warsztat_programowanie_obiektowe.Controllers
{
    public class WorkersModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: WorkersModels
        public ActionResult Index()
        {
            return View(db.workers.ToList());
        }

        // GET: WorkersModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersModel workersModel = db.workers.Find(id);
            if (workersModel == null)
            {
                return HttpNotFound();
            }
            return View(workersModel);
        }

        // GET: WorkersModels/Create
        public ActionResult Create()
        {
            PopulateAdressDropDownList(); 
            return View();
        }

        // POST: WorkersModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_worker,ID_adress,FirstName,LastName,PhoneNo")] WorkersModel workersModel)
        {
            if (ModelState.IsValid)
            {
                db.workers.Add(workersModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAdressDropDownList(workersModel.ID_adress);
            return View(workersModel);
        }

        // GET: WorkersModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersModel workersModel = db.workers.Find(id);
            if (workersModel == null)
            {
                return HttpNotFound();
            }
            PopulateAdressDropDownList();
            return View(workersModel);
        }

        // POST: WorkersModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_worker,ID_adress,FirstName,LastName,PhoneNo")] WorkersModel workersModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workersModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAdressDropDownList(workersModel.ID_adress);
            return View(workersModel);
        }

        // GET: WorkersModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkersModel workersModel = db.workers.Find(id);
            if (workersModel == null)
            {
                return HttpNotFound();
            }
            return View(workersModel);
        }

        // POST: WorkersModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkersModel workersModel = db.workers.Find(id);
            db.workers.Remove(workersModel);
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
        private void PopulateAdressDropDownList(object selectAdress = null)
        {
            var partAdress = from d in db.adresy
                            select d;
            ViewBag.ID_adress = new SelectList(partAdress, "ID_adress", null, selectAdress);
        }
    }
}
