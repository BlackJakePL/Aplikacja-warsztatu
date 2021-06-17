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
    public class AdressModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AdressModels
        [Authorize]
        public ActionResult Index()
        {
            return View(db.adresy.ToList());
        }

        // GET: AdressModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdressModel adressModel = db.adresy.Find(id);
            if (adressModel == null)
            {
                return HttpNotFound();
            }
            return View(adressModel);
        }

        // GET: AdressModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdressModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_adress,City,ZipCode,Street,BuildingNo,FlatNo")] AdressModel adressModel)
        {
            if (ModelState.IsValid)
            {
                db.adresy.Add(adressModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adressModel);
        }

        // GET: AdressModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdressModel adressModel = db.adresy.Find(id);
            if (adressModel == null)
            {
                return HttpNotFound();
            }
            return View(adressModel);
        }

        // POST: AdressModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_adress,City,ZipCode,Street,BuildingNo,FlatNo")] AdressModel adressModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adressModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adressModel);
        }

        // GET: AdressModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdressModel adressModel = db.adresy.Find(id);
            if (adressModel == null)
            {
                return HttpNotFound();
            }
            return View(adressModel);
        }

        // POST: AdressModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdressModel adressModel = db.adresy.Find(id);
            db.adresy.Remove(adressModel);
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
