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
    public class MendingModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MendingModels
        public ActionResult Index()
        {
            return View(db.mendings.ToList());
        }

        public ActionResult List(int? id)
        {
            MendingModel mending = db.mendings.Single(p => p.ID_mending == id);
            var allList = db.mendignList.ToList();
            var list = allList.Where(p => p.ID_mending == id);
            var parts = db.parts.ToList();
            mending.List = parts.Where(p => list.Any(q=> q.ID_part==p.ID_part));
            PopulatePartsDropDownList();
            return View(mending);
        }
        [HttpPost]
        public ActionResult ListAdd ([Bind(Include = "ID_mending,ID_part")] MendingListModel mendingListModel)
        {
            db.mendignList.Add(mendingListModel);
            var partNO = mendingListModel.ID_part;
            PartModel part = db.parts.Find(partNO);
            part.Stock = part.Stock - 1;
            db.Entry(part).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: MendingModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MendingModel mendingModel = db.mendings.Find(id);
            if (mendingModel == null)
            {
                return HttpNotFound();
            }
            return View(mendingModel);
        }

        // GET: MendingModels/Create
        public ActionResult Create()
        {

            PopulateCarsDropDownList();
            return View();
            
        }

        // POST: MendingModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_mending,VIN,MendingDate,MendingTime,ID_worker,MendingState")] MendingModel mendingModel)
        {
            if (ModelState.IsValid)
            {
                db.mendings.Add(mendingModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            PopulateCarsDropDownList(mendingModel.VIN);

            return View(mendingModel);
        }

        // GET: MendingModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MendingModel mendingModel = db.mendings.Find(id);
            if (mendingModel == null)
            {
                return HttpNotFound();
            }
            PopulateCarsDropDownList();
            return View(mendingModel);
        }

        // POST: MendingModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_mending,VIN,MendingDate,MendingTime,ID_worker,MendingState")] MendingModel mendingModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mendingModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateCarsDropDownList(mendingModel.VIN);
            return View(mendingModel);
        }

        // GET: MendingModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MendingModel mendingModel = db.mendings.Find(id);
            if (mendingModel == null)
            {
                return HttpNotFound();
            }
            return View(mendingModel);
        }

        // POST: MendingModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MendingModel mendingModel = db.mendings.Find(id);
            db.mendings.Remove(mendingModel);
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

        private void PopulateCarsDropDownList(object selectCar = null)
        {
            var carQuery = from d in db.cars
                                  orderby d.Year
                                  select d;
            ViewBag.VIN = new SelectList(carQuery, "VIN", null, selectCar);
        }

        private void PopulatePartsDropDownList(object selectPart = null)
        {
            var partQuery = from d in db.parts
                           orderby d.Name
                           select d;
            ViewBag.ID_part = new SelectList(partQuery, "ID_part", "Name", selectPart);
        }


    }
}
