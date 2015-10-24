using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using The_Journal.Models;

namespace The_Journal.Controllers
{
    public class CarersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Carers
        public ActionResult Index()
        {
            return View(db.Carers.ToList());
        }

        // GET: Carers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carer carer = db.Carers.Find(id);
            if (carer == null)
            {
                return HttpNotFound();
            }
            return View(carer);
        }

        // GET: Carers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarerID,FirstName,LastName,DOB,HomeNum,WorkNum,MobileNum,Address,PostCode,FamilyID,MainCarer")] Carer carer)
        {
            if (ModelState.IsValid)
            {
                db.Carers.Add(carer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carer);
        }

        // GET: Carers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carer carer = db.Carers.Find(id);
            if (carer == null)
            {
                return HttpNotFound();
            }
            return View(carer);
        }

        // POST: Carers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarerID,FirstName,LastName,DOB,HomeNum,WorkNum,MobileNum,Address,PostCode,FamilyID,MainCarer")] Carer carer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carer);
        }

        // GET: Carers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carer carer = db.Carers.Find(id);
            if (carer == null)
            {
                return HttpNotFound();
            }
            return View(carer);
        }

        // POST: Carers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carer carer = db.Carers.Find(id);
            db.Carers.Remove(carer);
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
