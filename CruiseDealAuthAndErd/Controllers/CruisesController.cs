﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CruiseDealAuthAndErd.Models;

namespace CruiseDealAuthAndErd.Controllers
{
    public class CruisesController : Controller
    {
        private CDModels db = new CDModels();

        // GET: Cruises
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Cruises.ToList());
        }

        // GET: Cruises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruise cruise = db.Cruises.Find(id);
            if (cruise == null)
            {
                return HttpNotFound();
            }
            return View(cruise);
        }

        // GET: Cruises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cruises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,Name,DepartDate,DepartPort,ReturnDate,Destination,Seats,Price")] Cruise cruise)
        {
            ModelState.Clear();
            TryValidateModel(cruise);
            if (ModelState.IsValid)
            {
                db.Cruises.Add(cruise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cruise);
        }

        // GET: Cruises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruise cruise = db.Cruises.Find(id);
            if (cruise == null)
            {
                return HttpNotFound();
            }
            return View(cruise);
        }

        // POST: Cruises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DepartDate,DepartPort,ReturnDate,Destination,Seats,Price")] Cruise cruise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cruise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cruise);
        }

        // GET: Cruises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cruise cruise = db.Cruises.Find(id);
            if (cruise == null)
            {
                return HttpNotFound();
            }
            return View(cruise);
        }

        // POST: Cruises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cruise cruise = db.Cruises.Find(id);
            db.Cruises.Remove(cruise);
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
