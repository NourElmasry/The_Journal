using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using The_Journal.Models;
using The_Journal.ViewModels;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;



namespace The_Journal.Controllers
{
    public class FamiliesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public void Save(FamilyViewModel data)
        {
            var family = new Family();

            var user = new ApplicationUser { UserName = "", Email = "" };
            var userMgr = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            userMgr.Create(user, "DefaultPassword");

            family.Account = user;

           // family.ApplicationUserID = user.Id;
            family.MainCarerID = 1;
            
            db.Family.Add(family);

            foreach (var child in data.Children)
            {
                var newChild = new Child();

                newChild.Family = family;
                newChild.FirstName = child.ChildFirstName;
                newChild.LastName = child.ChildLastName;
                newChild.KnownName = child.ChildKnownName;
                newChild.DOB = child.ChildDOB;
                newChild.Gender = child.ChildGender;
                newChild.Age = child.ChildAge;
                newChild.StartDate = child.ChildStartDate;
                newChild.EndDate = child.ChildEndDate;
                newChild.SEN = child.ChildSEN;
                newChild.KeyWorker = child.ChildKeyWorker;
                newChild.Allergy = child.ChildAllergy;
                newChild.Room = child.ChildRoom;

                db.Children.Add(newChild);
            }

            foreach(var carer in data.Carers)
            {
                var newCarer = new Carer();
                
                newCarer.Family = family;
                newCarer.FirstName = carer.CFirstName;
                newCarer.LastName = carer.CLastName;
                newCarer.DOB = carer.CDOB;
                newCarer.HomeNum = carer.CHomeNum;
                newCarer.WorkNum = carer.CWorkNum;
                newCarer.MobileNum = carer.CMobileNum;
                newCarer.Address = carer.CAddress;
                newCarer.PostCode = carer.CPostCode;
                
                db.Carers.Add(newCarer);

            }

            foreach (var eContact in data.EContacts)
            {
                var newEContact = new EmergencyContact();

                newEContact.Family = family;
                newEContact.FirstName = eContact.ECFirstName;
                newEContact.LastName = eContact.ECLastName;
                newEContact.MobileNum = eContact.ECMobileNum;
                newEContact.Relationship = eContact.ECRelationship;


                db.EmergencyContacts.Add(newEContact);
            }

            
            db.SaveChanges();

           // db.Family.Find()
        }

        // GET: Families
        public ActionResult Index()
        {
            var family = db.Family.Include(f => f.Account);
            return View(family.ToList());
        }

        // GET: Families/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family family = db.Family.Find(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        // GET: Families/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Families/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FamilyID,ApplicationUserID,MainCarerID")] Family family)
        {
            if (ModelState.IsValid)
            {
                db.Family.Add(family);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "Email", family.ApplicationUserID);
            return View(family);
        }

        // GET: Families/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family family = db.Family.Find(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "Email", family.ApplicationUserID);
            return View(family);
        }

        // POST: Families/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FamilyID,ApplicationUserID,MainCarerID")] Family family)
        {
            if (ModelState.IsValid)
            {
                db.Entry(family).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserID = new SelectList(db.Users, "Id", "Email", family.ApplicationUserID);
            return View(family);
        }

        // GET: Families/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Family family = db.Family.Find(id);
            if (family == null)
            {
                return HttpNotFound();
            }
            return View(family);
        }

        // POST: Families/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Family family = db.Family.Find(id);
            db.Family.Remove(family);
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
