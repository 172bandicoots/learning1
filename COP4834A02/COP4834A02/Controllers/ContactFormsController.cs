using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COP4834A02.Models;
using Newtonsoft.Json;

namespace COP4834A02.Controllers
{
    public class ContactFormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactForms
      
        public ActionResult Index()
        {
            return View(db.ContactForms.ToList());
        }

        //GET: Confirm page
        public ActionResult Confirm()
        {
            return View("Confirm");
        }

        // GET: ContactForms/Details/5
        [Authorize()]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //HttpStatusCode.BadRequest
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = db.ContactForms.Find(id);
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // GET: ContactForms/Create
      
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContactID,FirstName,LastName,Address,City,State,Zipcode,PhoneNumber,Email,BirthDate,Message")] ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                string EncodedResponse = Request.Form["g-recaptcha-Response"];
                bool IsCaptchaValid = (ReCaptchaClass.Validate(EncodedResponse) == "True" ? true : false);
                if (IsCaptchaValid)
                {

                 db.ContactForms.Add(contactForm);
                db.SaveChanges();
                return RedirectToAction("Index"); //redirect
                                                  //this will redirect back to start page :-)
                                                  //return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                else
                {
                    TempData["recaptcha"] = "Please verify that you are not a robot";
                }
             
            }

            return View(contactForm);
        }

        // GET: ContactForms/Edit/5
        [Authorize()]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = db.ContactForms.Find(id);
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // POST: ContactForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContactID,FirstName,LastName,Address,City,State,Zipcode,PhoneNumber,Email,BirthDate,Message")] ContactForm contactForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactForm);
        }

        // GET: ContactForms/Delete/5
        [Authorize()]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactForm contactForm = db.ContactForms.Find(id);
            if (contactForm == null)
            {
                return HttpNotFound();
            }
            return View(contactForm);
        }

        // POST: ContactForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactForm contactForm = db.ContactForms.Find(id);
            db.ContactForms.Remove(contactForm);
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
