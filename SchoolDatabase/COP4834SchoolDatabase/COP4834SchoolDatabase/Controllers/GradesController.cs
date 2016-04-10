using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COP4834SchoolDatabase.Models;
using System.Diagnostics;
using System.Data.Entity.Core.Metadata.Edm;

namespace COP4834SchoolDatabase.Controllers
{
    public class GradesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Grades
        public ActionResult Index()
        {
            var grades = db.Grades.Include(g => g.Assignments).Include(g => g.Students);
            return View(grades.ToList());
        }

        // GET: GradesView
        public ActionResult GradesView()
        {
            var grades = db.Grades.Include(g => g.Assignments).Include(g => g.Students);
            return View(grades.ToList());
        }
        // GET: grade message for when create is denied due to custom logic
        public ActionResult grade_message()
        {
            return View("grade_message");
        }

        // GET: Grades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // GET: Grades/Create
        public ActionResult Create()
        {
            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "AssignmentName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName");
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradeID,StudentID,AssignmentID,Score")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                //Determine if there the student already has a recorded grade for this assignment
                //If so, do not create new.  Use EDIT for the record instead.
                //otherwise grades will stack
               
                var total = db.Database.SqlQuery<int>("SELECT COUNT(*) FROM dbo.Grades").Single();
                if (total == 0)
                {
                    //no grade exists for anyone, so no check needs to be done before adding
                    db.Grades.Add(grade);
                }
                else
                {
                    foreach (var item in db.Grades)
                    {
                        if (!(item.AssignmentID == grade.AssignmentID && item.StudentID == grade.StudentID))
                        {
                            Debug.Write(item.AssignmentID + " " + item.StudentID);
                            //This student does not have a grade for this assignment so add the record    
                            db.Grades.Add(grade);
                        }
                        else
                        {
                            //this student already has a grade for this assignment
                            return RedirectToAction("grade_message");
                        }
                    }
                }
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "AssignmentName", grade.AssignmentID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", grade.StudentID);
            return View(grade);
        }

        // GET: Grades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "AssignmentName", grade.AssignmentID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", grade.StudentID);
            return View(grade);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradeID,StudentID,AssignmentID,Score")] Grade grade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignmentID = new SelectList(db.Assignments, "AssignmentID", "AssignmentName", grade.AssignmentID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "StudentName", grade.StudentID);
            return View(grade);
        }

        // GET: Grades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(grade);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grade grade = db.Grades.Find(id);
            db.Grades.Remove(grade);
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
