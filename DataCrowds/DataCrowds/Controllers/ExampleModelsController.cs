using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataCrowds.Models;

namespace DataCrowds.Controllers
{
    public class ExampleModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExampleModels
        public ActionResult Index()
        {
            return View(db.ExampleModels.ToList());
        }

        // GET: ExampleModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExampleModels exampleModels = db.ExampleModels.Find(id);
            if (exampleModels == null)
            {
                return HttpNotFound();
            }
            return View(exampleModels);
        }

        // GET: ExampleModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExampleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExampleID,name")] ExampleModels exampleModels)
        {
            if (ModelState.IsValid)
            {
                db.ExampleModels.Add(exampleModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exampleModels);
        }

        // GET: ExampleModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExampleModels exampleModels = db.ExampleModels.Find(id);
            if (exampleModels == null)
            {
                return HttpNotFound();
            }
            return View(exampleModels);
        }

        // POST: ExampleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExampleID,name")] ExampleModels exampleModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exampleModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exampleModels);
        }

        // GET: ExampleModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExampleModels exampleModels = db.ExampleModels.Find(id);
            if (exampleModels == null)
            {
                return HttpNotFound();
            }
            return View(exampleModels);
        }

        // POST: ExampleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExampleModels exampleModels = db.ExampleModels.Find(id);
            db.ExampleModels.Remove(exampleModels);
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
