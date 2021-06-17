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
    public class DealerModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DealerModels
        public ActionResult Index()
        {
            return View(db.dealers.ToList());
        }

        // GET: DealerModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerModel dealerModel = db.dealers.Find(id);
            if (dealerModel == null)
            {
                return HttpNotFound();
            }
            return View(dealerModel);
        }

        // GET: DealerModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DealerModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_dealer,Name,PhoneNo,NIP")] DealerModel dealerModel)
        {
            if (ModelState.IsValid)
            {
                db.dealers.Add(dealerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dealerModel);
        }

        // GET: DealerModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerModel dealerModel = db.dealers.Find(id);
            if (dealerModel == null)
            {
                return HttpNotFound();
            }
            return View(dealerModel);
        }

        // POST: DealerModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_dealer,Name,PhoneNo,NIP")] DealerModel dealerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dealerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dealerModel);
        }

        // GET: DealerModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DealerModel dealerModel = db.dealers.Find(id);
            if (dealerModel == null)
            {
                return HttpNotFound();
            }
            return View(dealerModel);
        }

        // POST: DealerModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DealerModel dealerModel = db.dealers.Find(id);
            db.dealers.Remove(dealerModel);
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
