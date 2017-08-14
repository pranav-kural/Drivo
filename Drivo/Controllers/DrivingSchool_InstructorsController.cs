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
    public class DrivingSchool_InstructorsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: DrivingSchool_Instructors
        public ActionResult Index()
        {
            var drivingSchool_Instructors = db.DrivingSchool_Instructors.Include(d => d.DrivingSchool).Include(d => d.Instructor);
            return View(drivingSchool_Instructors.ToList());
        }

        // GET: DrivingSchool_Instructors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool_Instructors drivingSchool_Instructors = db.DrivingSchool_Instructors.Find(id);
            if (drivingSchool_Instructors == null)
            {
                return HttpNotFound();
            }
            return View(drivingSchool_Instructors);
        }

        // GET: DrivingSchool_Instructors/Create
        public ActionResult Create()
        {
            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchools, "DrivingSchoolId", "Name");
            ViewBag.InstructorId = new SelectList(db.Instructors, "InstructorId", "Firstname");
            return View();
        }

        // POST: DrivingSchool_Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InstructorsDrivingSchoolId,CreateDate,EditDate,InstructorId,DrivingSchoolId")] DrivingSchool_Instructors drivingSchool_Instructors)
        {
            if (ModelState.IsValid)
            {
                db.DrivingSchool_Instructors.Add(drivingSchool_Instructors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchools, "DrivingSchoolId", "Name", drivingSchool_Instructors.DrivingSchoolId);
            ViewBag.InstructorId = new SelectList(db.Instructors, "InstructorId", "Firstname", drivingSchool_Instructors.InstructorId);
            return View(drivingSchool_Instructors);
        }

        // GET: DrivingSchool_Instructors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool_Instructors drivingSchool_Instructors = db.DrivingSchool_Instructors.Find(id);
            if (drivingSchool_Instructors == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchools, "DrivingSchoolId", "Name", drivingSchool_Instructors.DrivingSchoolId);
            ViewBag.InstructorId = new SelectList(db.Instructors, "InstructorId", "Firstname", drivingSchool_Instructors.InstructorId);
            return View(drivingSchool_Instructors);
        }

        // POST: DrivingSchool_Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstructorsDrivingSchoolId,CreateDate,EditDate,InstructorId,DrivingSchoolId")] DrivingSchool_Instructors drivingSchool_Instructors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drivingSchool_Instructors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DrivingSchoolId = new SelectList(db.DrivingSchools, "DrivingSchoolId", "Name", drivingSchool_Instructors.DrivingSchoolId);
            ViewBag.InstructorId = new SelectList(db.Instructors, "InstructorId", "Firstname", drivingSchool_Instructors.InstructorId);
            return View(drivingSchool_Instructors);
        }

        // GET: DrivingSchool_Instructors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool_Instructors drivingSchool_Instructors = db.DrivingSchool_Instructors.Find(id);
            if (drivingSchool_Instructors == null)
            {
                return HttpNotFound();
            }
            return View(drivingSchool_Instructors);
        }

        // POST: DrivingSchool_Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DrivingSchool_Instructors drivingSchool_Instructors = db.DrivingSchool_Instructors.Find(id);
            db.DrivingSchool_Instructors.Remove(drivingSchool_Instructors);
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
