using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drivo.Models;

namespace Drivo.Controllers
{
    public class DrivingSchoolsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: DrivingSchools
        public ActionResult Index()
        {
            return View(db.DrivingSchools.ToList());
        }

        // GET: DrivingSchools/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool drivingSchool = db.DrivingSchools.Find(id);
            if (drivingSchool == null)
            {
                return HttpNotFound();
            }
            return View(drivingSchool);
        }

        // GET: DrivingSchools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrivingSchools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrivingSchoolId,Name,Working_since,Email,PasswordHash,PhoneNumber,UserName,About,Licences_training_for,Province,Cities_of_operation,Vehicles_used")] DrivingSchool drivingSchool)
        {
            if (ModelState.IsValid)
            {
                db.DrivingSchools.Add(drivingSchool);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drivingSchool);
        }

        // GET: DrivingSchools/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool drivingSchool = db.DrivingSchools.Find(id);
            if (drivingSchool == null)
            {
                return HttpNotFound();
            }
            return View(drivingSchool);
        }

        // POST: DrivingSchools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrivingSchoolId,Name,Working_since,Email,PasswordHash,PhoneNumber,UserName,About,Licences_training_for,Province,Cities_of_operation,Vehicles_used")] DrivingSchool drivingSchool)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drivingSchool).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drivingSchool);
        }

        // GET: DrivingSchools/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool drivingSchool = db.DrivingSchools.Find(id);
            if (drivingSchool == null)
            {
                return HttpNotFound();
            }
            return View(drivingSchool);
        }

        // POST: DrivingSchools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DrivingSchool drivingSchool = db.DrivingSchools.Find(id);
            db.DrivingSchools.Remove(drivingSchool);
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
