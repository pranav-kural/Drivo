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
    public class DrivingSchoolsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: DrivingSchools
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.DrivingSchools.ToList());
        }

        // GET: DrivingSchools/Details/5
        [AllowAnonymous]
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrivingSchool drivingSchool = db.DrivingSchools.Include(x => x.DrivingSchool_Instructors.Select(m => m.Instructor)).SingleOrDefault(y => y.DrivingSchoolId == id); ;

            // Extract ID's of instructors which are related to this driving school
            string[] instructorsIds = drivingSchool.DrivingSchool_Instructors.Select(x => x.InstructorId).ToArray();

            // Load instructor objects with id which is present in the list above
            ViewBag.Instructors = db.Instructors.Where(x => instructorsIds.Contains(x.InstructorId));


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
        public ActionResult Create([Bind(Include = "DrivingSchoolId,Name,Working_since,Email,PhoneNumber,UserName,About,Licences_training_for,Province,Cities_of_operation,Vehicles_used")] DrivingSchool model, string PasswordHash)
        {
            // check if a driving school with same name already exists
            DrivingSchool checkmodel = db.DrivingSchools.SingleOrDefault(x => x.Name == model.Name && x.Working_since == model.Working_since);

            // check if the username entered already exists
            DrivingSchool check_user_account = db.DrivingSchools.SingleOrDefault(x => x.UserName == model.UserName);

            // if there is no duplication
            if (checkmodel == null || check_user_account == null)
            {
                if (ModelState.IsValid)
                {
                    // Create a password has using the PasswordStorage external library
                    model.PasswordHash = Drivo.ExternalLibraries.PasswordStorage.CreateHash(PasswordHash);
                    // Add the driving school
                    db.DrivingSchools.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                // Give error based on the duplication found
                if (checkmodel == null)
                {
                    ModelState.AddModelError("", "A Driving School with the same name and Year of establishment" + (check_user_account == null ? " and username" : "") + " already exists. If you already have an account, please try to login.");
                }
                else
                {
                    ModelState.AddModelError("", "An account with the same username already exists. Please, try again with a different username.");
                }
            }

            return View(model);
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
        public ActionResult Edit([Bind(Include = "DrivingSchoolId,Name,Working_since,Email,PhoneNumber,UserName,About,Licences_training_for,Province,Cities_of_operation,Vehicles_used")] DrivingSchool model, string PasswordHash)
        {
            // check if a driving school with same name already exists
            DrivingSchool checkmodel = db.DrivingSchools.SingleOrDefault(x => x.Name == model.Name && x.Working_since == model.Working_since);

            // check if the username entered already exists
            DrivingSchool check_user_account = db.DrivingSchools.SingleOrDefault(x => x.UserName == model.UserName);

            // if there is no duplication
            if (checkmodel == null || check_user_account == null)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                // Give error based on the duplication found
                if (checkmodel == null)
                {
                    ModelState.AddModelError("", "A Driving School with the same name and Year of establishment" + (check_user_account == null ? " and username" : "") + " already exists. If you already have an account, please try to login.");
                }
                else
                {
                    ModelState.AddModelError("", "An account with the same username already exists. Please, try again with a different username.");
                }
            }

            return View(model);
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

        // GET: DrivingSchools/AddInstructor/DrivingSchoolId
        public ActionResult AddInstructor(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            DrivingSchool drivingSchool = db.DrivingSchools.Include(x => x.DrivingSchool_Instructors.Select(m => m.Instructor)).SingleOrDefault(y => y.DrivingSchoolId == id); ;

            // Extract ID's of instructors which are related to this driving school
            string[] instructorsIds = drivingSchool.DrivingSchool_Instructors.Select(x => x.InstructorId).ToArray();

            // Load instructor objects with id which is present in the list above
            ViewBag.Instructors = db.Instructors.Where(x => !instructorsIds.Contains(x.InstructorId));
            
            return View(drivingSchool);
        }

        // POST: DrivingSchools/AddInstructor/DrivingSchoolId
        [HttpPost]
        public ActionResult AddInstructor([Bind(Include = "DrivingSchoolId")] DrivingSchool model, string[] InstructorIds)
        {
           
            if (InstructorIds != null)
            {
                foreach (string instructorId in InstructorIds)
                {
                    DrivingSchool_Instructors drivingschool_instructors = new DrivingSchool_Instructors();
                    drivingschool_instructors.InstructorId = instructorId;
                    drivingschool_instructors.DrivingSchoolId = model.DrivingSchoolId;
                    db.DrivingSchool_Instructors.Add(drivingschool_instructors);
                }
                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }

        // GET: /DrivingSchools/RemoveInstructor/DrivingSchoolId
        public ActionResult RemoveInstructor(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            DrivingSchool drivingSchool = db.DrivingSchools.Include(x => x.DrivingSchool_Instructors.Select(m => m.Instructor)).SingleOrDefault(y => y.DrivingSchoolId == id); ;

            // Extract ID's of instructors which are related to this driving school
            string[] instructorsIds = drivingSchool.DrivingSchool_Instructors.Select(x => x.InstructorId).ToArray();

            // Load instructor objects with id which is present in the list above
            ViewBag.Instructors = db.Instructors.Where(x => instructorsIds.Contains(x.InstructorId));

            ViewBag.Driving = drivingSchool.DrivingSchool_Instructors.Select(x => x.InstructorsDrivingSchoolId);

            return View(drivingSchool);
        }

        // POST: DrivingSchools/AddInstructor/DrivingSchoolId
        [HttpPost]
        public ActionResult RemoveInstructor([Bind(Include = "DrivingSchoolId")] DrivingSchool model, string[] InstructorIds)
        {
            // check if there are any instructors selected to be deleted
            if (InstructorIds != null)
            {
                DrivingSchool tmpmodel = db.DrivingSchools.Find(model.DrivingSchoolId); 

                var removeInstructors = tmpmodel.DrivingSchool_Instructors.Where(x => InstructorIds.Contains(x.InstructorId)).ToList();
                foreach (var InstructorsToRemove in removeInstructors)
                {
                    db.Entry(InstructorsToRemove).State = EntityState.Deleted;
                }

                db.SaveChanges();

            }

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
