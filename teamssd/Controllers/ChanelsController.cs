﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using teamssd.Data;
using teamssd.Data.Entities;

namespace teamssd.Controllers
{
    public class ChanelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Chanels
        public ActionResult Index()
        {
            var chanels = db.Chanels.Include(c => c.Owner);
            return View(chanels.ToList());
        }

        // GET: Chanels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chanel chanel = db.Chanels.Find(id);
            if (chanel == null)
            {
                return HttpNotFound();
            }
            return View(chanel);
        }

        // GET: Chanels/Create
        public ActionResult Create()
        {
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Chanels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Text,OwnerId")] Chanel chanel)
        {
            if (ModelState.IsValid)
            {
                db.Chanels.Add(chanel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", chanel.OwnerId);
            return View(chanel);
        }

        // GET: Chanels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chanel chanel = db.Chanels.Find(id);
            if (chanel == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", chanel.OwnerId);
            return View(chanel);
        }

        // POST: Chanels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Text,OwnerId")] Chanel chanel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chanel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerId = new SelectList(db.Users, "Id", "FirstName", chanel.OwnerId);
            return View(chanel);
        }

        // GET: Chanels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chanel chanel = db.Chanels.Find(id);
            if (chanel == null)
            {
                return HttpNotFound();
            }
            return View(chanel);
        }

        // POST: Chanels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chanel chanel = db.Chanels.Find(id);
            db.Chanels.Remove(chanel);
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