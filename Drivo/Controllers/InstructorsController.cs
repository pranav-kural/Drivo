using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Drivo.Models;
using Drivo.Custom_Annotations;

namespace Drivo.Controllers
{
    [AuthorizeUser]
    public class InstructorsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Instructors
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Instructors.ToList());
        }

        // GET: Instructors/Details/5
        [AllowAnonymous]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // GET: Instructors/Create
        public ActionResult Create()
        {
            Instructor model = new Instructor();
            ViewBag.DrivingSchools = new MultiSelectList(db.DrivingSchools.ToList(), "DrivingSchoolId", "Name", model.DrivingSchool_Instructors.Select(x => x.DrivingSchoolId).ToArray());
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Firstname,Lastname,DOB,Gender,Driving_instructor_licence,Working_since,Email,PhoneNumber,UserName,About,Licences_held,Licences_training_for,Province,Cities_of_operation,Vehicles_used,DrivingSchoolsIds")] Instructor model, string DrivingSchoolsId, string PasswordHash)
        {
            // check if an instructor with the same firstname, lastname and dob already exists
            Instructor checkmodel = db.Instructors.SingleOrDefault(x => x.Firstname == model.Firstname && x.Lastname == model.Lastname && x.DOB == model.DOB);

            // check if the username entered already exists
            Instructor check_user_account = db.Instructors.SingleOrDefault(x => x.UserName == model.UserName);

            // if any duplication isn't found
            if (checkmodel == null || check_user_account == null)
            {
                if (ModelState.IsValid)
                {
                    // Create a password has using the PasswordStorage external library
                    model.PasswordHash = Drivo.ExternalLibraries.PasswordStorage.CreateHash(PasswordHash);
                    // Add the instructor model
                    db.Instructors.Add(model);
                    db.SaveChanges();

                    // check if there is any Driving School the new instructor is affiliated to
                    if (DrivingSchoolsId != null && DrivingSchoolsId != "none")
                    {
                        // Create a new Driving School Instructor relationship
                        DrivingSchool_Instructors drivingschool_affiliation = new DrivingSchool_Instructors();
                        drivingschool_affiliation.InstructorId = model.InstructorId;
                        drivingschool_affiliation.DrivingSchoolId = DrivingSchoolsId;
                        model.DrivingSchool_Instructors.Add(drivingschool_affiliation);
                        db.Entry(model).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
            }
            else
            {
                // Give error based on the duplication found
                if (checkmodel == null)
                {
                    ModelState.AddModelError("", "An instructor with the same name and date of birth" + (check_user_account == null ? " and username" : "") + " already exists. If you already have an account, please try to login.");
                }
                else
                {
                    ModelState.AddModelError("", "An instructor with the same username already exists. Please, try again with a different username.");
                }
            }
            ViewBag.DrivingSchools = new MultiSelectList(db.DrivingSchools.ToList(), "DrivingSchoolId", "Name", model.DrivingSchool_Instructors.Select(x => x.DrivingSchoolId).ToArray());

            return View(model);
        }

        // GET: Instructors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }

            ViewBag.DrivingSchools = new MultiSelectList(db.DrivingSchools.ToList(), "DrivingSchoolId", "Name", instructor.DrivingSchool_Instructors.Select(x => x.DrivingSchoolId).ToArray());

            return View(instructor);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InstructorId,Firstname,Lastname,DOB,Gender,Driving_instructor_licence,Working_since,Email,PasswordHash,PhoneNumber,UserName,About,Licences_held,Licences_training_for,Province,Cities_of_operation,Vehicles_used")] Instructor model)
        {
            
                if (ModelState.IsValid)
                {
                    
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            
            ViewBag.DrivingSchools = new MultiSelectList(db.DrivingSchools.ToList(), "DrivingSchoolId", "Name", model.DrivingSchool_Instructors.Select(x => x.DrivingSchoolId).ToArray());

            return View(model);
        }

        // GET: Instructors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instructor instructor = db.Instructors.Find(id);
            if (instructor == null)
            {
                return HttpNotFound();
            }
            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Instructor instructor = db.Instructors.Find(id);
            db.Instructors.Remove(instructor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult InstructorsNavigation()
        {
            return PartialView("_InstructorsNavigation");
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
