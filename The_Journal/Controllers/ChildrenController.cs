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
    public class ChildrenController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Children
        public ActionResult Index()
        {
            var children = db.Children.Include(c => c.Family).Include(c => c.KeyWorker).Include(c => c.Room);
            return View(children.ToList());
        }

        // GET: Children/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = db.Children.Find(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        // GET: Children/Create
        public ActionResult Create()
        {
            ViewBag.FamilyID = new SelectList(db.Family, "FamilyID", "ApplicationUserID");
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName");
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID");
            return View();
        }

        // POST: Children/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChildID,FirstName,LastName,KnownName,Gender,DOB,Age,StartDate,EndDate,SEN,FamilyID,EmployeeID,RoomID,Allergy")] Child child)
        {
            if (ModelState.IsValid)
            {
                db.Children.Add(child);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FamilyID = new SelectList(db.Family, "FamilyID", "ApplicationUserID", child.FamilyID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", child.EmployeeID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID", child.RoomID);
            return View(child);
        }

        // GET: Children/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = db.Children.Find(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyID = new SelectList(db.Family, "FamilyID", "ApplicationUserID", child.FamilyID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", child.EmployeeID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID", child.RoomID);
            return View(child);
        }

        // POST: Children/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChildID,FirstName,LastName,KnownName,Gender,DOB,Age,StartDate,EndDate,SEN,FamilyID,EmployeeID,RoomID,Allergy")] Child child)
        {
            if (ModelState.IsValid)
            {
                db.Entry(child).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FamilyID = new SelectList(db.Family, "FamilyID", "ApplicationUserID", child.FamilyID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "FirstName", child.EmployeeID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "RoomID", child.RoomID);
            return View(child);
        }

        // GET: Children/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = db.Children.Find(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        // POST: Children/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Child child = db.Children.Find(id);
            db.Children.Remove(child);
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
