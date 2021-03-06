﻿using System;
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
using System.Data.Entity.Validation;
using System.Diagnostics;



namespace The_Journal.Controllers
{
    public class FamiliesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public ActionResult Save(FamilyViewModel data)
        {
            var status = new StatusViewModel();
            status.IsSuccessful = true;
            var family = new Family();

            var user = new ApplicationUser { UserName = data.Carers[0].CEmail, Email = data.Carers[0].CEmail };
            var userMgr = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            userMgr.Create(user, "DefaultPassword");

            family.Account = user;

            Carer mainCarer = null;

          // family.MainCarer = 1;
            
            db.Family.Add(family);
           
            foreach (var child in data.Children)
            {
                Child newChild;

                if (child.ChildID == 0)
                {
                     newChild = new Child();
                }
                else
                {
                    newChild = db.Children.Find(child.ChildID);
                }

                newChild.Family = family;
                newChild.FirstName = child.ChildFirstName;
                newChild.LastName = child.ChildLastName;
                newChild.KnownName = child.ChildKnownName;
                newChild.DOB = child.ChildDOB;
                newChild.Gender = child.Gender;
                newChild.Age = DateTime.Now.Year - newChild.DOB.Year;
                newChild.StartDate = child.ChildStartDate;
                newChild.EndDate = child.ChildEndDate;
                newChild.SEN = child.ChildSEN;
                newChild.EmployeeID = child.EmployeeID;
                newChild.Allergy = child.ChildAllergy;
                newChild.RoomID = child.RoomID;

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
                newCarer.Email = carer.CEmail;

                db.Carers.Add(newCarer);

                if (carer.CMainCarer == true)
                {
                    mainCarer = newCarer;
                }
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


            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                status.IsSuccessful = false;

                foreach (var eve in e.EntityValidationErrors)
                {
                    Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        status.ValidationErrors.Add(string.Format("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage));
                    }
                }
                throw;
            }

            family.MainCarerID = mainCarer.CarerID;
            family.FamilyName = mainCarer.FullName;
            db.SaveChanges();

            return Json(status, JsonRequestBehavior.AllowGet);
          
        }

        //Load Data and send to KO as JSON
        public ActionResult Load(int familyId)
        {
            var vm = new FamilyViewModel();

            Family family = db.Family.Find(familyId);
            if (family == null)
            {
                return HttpNotFound();
            }

            foreach (var child in family.Children)
            {
                var newChild = new ChildViewModel();

                newChild.ChildFirstName = child.FirstName;
                newChild.ChildLastName = child.LastName;
                newChild.ChildKnownName = child.KnownName;
                newChild.ChildDOB = child.DOB;
                newChild.Gender = child.Gender;
                newChild.ChildAge = DateTime.Now.Year - newChild.ChildDOB.Year;
                newChild.ChildStartDate = child.StartDate;
                newChild.ChildEndDate = child.EndDate;
                newChild.ChildSEN = child.SEN;
                newChild.EmployeeID = child.EmployeeID;
                newChild.ChildAllergy = child.Allergy;
                newChild.RoomID = child.RoomID;

                vm.Children.Add(newChild);
            }

            foreach (var carer in family.Carers)
            {
                var newCarer = new CarerViewModel();

                
                newCarer.CFirstName = carer.FirstName;
                newCarer.CLastName = carer.LastName;
                newCarer.CDOB = carer.DOB;
                newCarer.CHomeNum = carer.HomeNum;
                newCarer.CWorkNum = carer.WorkNum;
                newCarer.CMobileNum = carer.MobileNum;
                newCarer.CAddress = carer.Address;
                newCarer.CPostCode = carer.PostCode;
                newCarer.CEmail = carer.Email;

                vm.Carers.Add(newCarer);
            }

            foreach (var eContact in family.EmergencyContacts)
            {
                var newEContact = new EContactViewModel();

                newEContact.ECFirstName = eContact.FirstName;
                newEContact.ECLastName = eContact.LastName;
                newEContact.ECMobileNum = eContact.MobileNum;
                newEContact.ECRelationship = eContact.Relationship;


                vm.EContacts.Add(newEContact);
            }

            return Json(vm, JsonRequestBehavior.AllowGet);
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
