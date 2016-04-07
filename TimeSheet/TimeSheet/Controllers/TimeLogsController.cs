using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeSheet.Models;

namespace TimeSheet.Controllers
{
    public class TimeLogsController : Controller
    {
        private dbContext db = new dbContext();

        // GET: TimeLogs
        public ActionResult Index()
        {
            var timeLogs = db.TimeLogs.Include(t => t.Associates).Include(t => t.Clients);
            return View(timeLogs.ToList());
        }

        // GET: TimeLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeLog timeLog = db.TimeLogs.Find(id);
            if (timeLog == null)
            {
                return HttpNotFound();
            }
            return View(timeLog);
        }
      
        // GET: TimeLogs
        public ActionResult UserView()
        {
            var timeLogs = db.TimeLogs.Include(t => t.Associates).Include(t => t.Clients);
            return View(timeLogs.ToList());
        }


        // GET: TimeLogs/Create
        public ActionResult Create()
        {
            ViewBag.AssociateID = new SelectList(db.Associates, "AssociateID", "FirstName");
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "CompanyName");
            return View();
        }

        // POST: TimeLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LogID,TimeStamp,AssociateID,ClientID,WorkDate,NumberHours,WorkType,JobNote")] TimeLog timeLog)
        {
            if (ModelState.IsValid)
            {
                db.TimeLogs.Add(timeLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssociateID = new SelectList(db.Associates, "AssociateID", "FirstName", timeLog.AssociateID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "CompanyName", timeLog.ClientID);
            return View(timeLog);
        }

        // GET: TimeLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeLog timeLog = db.TimeLogs.Find(id);
            if (timeLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssociateID = new SelectList(db.Associates, "AssociateID", "FirstName", timeLog.AssociateID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "CompanyName", timeLog.ClientID);
            return View(timeLog);
        }

        // POST: TimeLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LogID,TimeStamp,AssociateID,ClientID,WorkDate,NumberHours,WorkType,JobNote")] TimeLog timeLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssociateID = new SelectList(db.Associates, "AssociateID", "FirstName", timeLog.AssociateID);
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "CompanyName", timeLog.ClientID);
            return View(timeLog);
        }

        // GET: TimeLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeLog timeLog = db.TimeLogs.Find(id);
            if (timeLog == null)
            {
                return HttpNotFound();
            }
            return View(timeLog);
        }

        // POST: TimeLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeLog timeLog = db.TimeLogs.Find(id);
            db.TimeLogs.Remove(timeLog);
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
