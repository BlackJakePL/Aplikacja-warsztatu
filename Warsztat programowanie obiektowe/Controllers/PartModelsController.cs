using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Warsztat_programowanie_obiektowe.Models;
using PagedList;

namespace Warsztat_programowanie_obiektowe.Controllers
{
    public class PartModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PartModels
        public ActionResult Index(string sortOrder,  int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParam = sortOrder == "Price" ? "price_desc" : "Price";

            var parts = from p in db.parts select p;

            switch (sortOrder)
            {

                case "name_desc":
                    parts = parts.OrderByDescending(s => s.Name);
                    break;
                case "Price":
                    parts = parts.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    parts = parts.OrderByDescending(p => p.Price);
                    break;
                default:
                    parts = parts.OrderBy(p => p.Name);
                    break;
            }

            int pageSize = 2;
            int pageNumber = (page ?? 1);


            return View(parts.ToPagedList(pageNumber, pageSize));

        }

        // GET: PartModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartModel partModel = db.parts.Find(id);
            if (partModel == null)
            {
                return HttpNotFound();
            }
            return View(partModel);
        }

        // GET: PartModels/Create
        public ActionResult Create()
        {
            PopulateDealersDropDownList();

            return View();
        }

        // POST: PartModels/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_part,Name,Price,ID_dealer")] PartModel partModel)
        {
            if (ModelState.IsValid)
            {
                db.parts.Add(partModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateDealersDropDownList(partModel.ID_dealer);
            return View(partModel);
        }

        // GET: PartModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartModel partModel = db.parts.Find(id);
            if (partModel == null)
            {
                return HttpNotFound();
            }
            PopulateDealersDropDownList(partModel.ID_dealer);
            return View(partModel);
        }

        // POST: PartModels/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_part,Name,Stock,Price,ID_dealer")] PartModel partModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                PopulateDealersDropDownList(partModel.ID_dealer);

                return View(partModel);

        }

        // GET: PartModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartModel partModel = db.parts.Find(id);
            if (partModel == null)
            {
                return HttpNotFound();
            }
            return View(partModel);
        }

        // POST: PartModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartModel partModel = db.parts.Find(id);
            db.parts.Remove(partModel);
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

        private void PopulateDealersDropDownList(object selectDdealer = null)
        {
            var dealerQuery = from d in db.dealers
                            orderby d.Name
                            select d;
            ViewBag.ID_dealer = new SelectList(dealerQuery, "ID_dealer", "Name", selectDdealer);
        }
    }
}
