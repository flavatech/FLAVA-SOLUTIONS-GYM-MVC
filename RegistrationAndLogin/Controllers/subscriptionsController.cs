using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RegistrationAndLogin.Models;

namespace RegistrationAndLogin.Controllers
{
    public class subscriptionsController : Controller
    {
        private FlavaSolutionsGymnMVCEntities db = new FlavaSolutionsGymnMVCEntities();

        // GET: subscriptions
        public ActionResult Index()
        {
            var subscriptions = db.subscriptions.Include(s => s.User);
            return View(subscriptions.ToList());
        }

        // GET: subscriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subscription subscription = db.subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // GET: subscriptions/Create
        public ActionResult Create()
        {
            ViewBag.addedBy = new SelectList(db.Users, "UserID", "FirstName");
            return View();
        }

        // POST: subscriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,category,description,price,quantity,dateAdded,addedBy")] subscription subscription)
        {
            if (ModelState.IsValid)
            {
                subscription.dateAdded = DateTime.UtcNow;
                db.subscriptions.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.addedBy = new SelectList(db.Users, "UserID", "FirstName", subscription.addedBy);
            return View(subscription);
        }

        // GET: subscriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subscription subscription = db.subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.addedBy = new SelectList(db.Users, "UserID", "FirstName", subscription.addedBy);
            return View(subscription);
        }

        // POST: subscriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,category,description,price,quantity,dateAdded,addedBy")] subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.addedBy = new SelectList(db.Users, "UserID", "FirstName", subscription.addedBy);
            return View(subscription);
        }

        // GET: subscriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subscription subscription = db.subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subscription subscription = db.subscriptions.Find(id);
            db.subscriptions.Remove(subscription);
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
