using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SurveyTool.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DataCrowds.Models
{
    public class DataSetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DataSets
        public ActionResult Index()
        {
            List<DataSet> ds = new List<DataSet>();

            foreach (DataSet data in db.DataSets) {
                if (data.UserId == User.Identity.GetUserId()) {
                    ds.Add(data);
                }
            }

            return View(ds);
        }


        // GET: DataSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataSet dataSet = db.DataSets.Find(id);
            if (dataSet == null)
            {
                return HttpNotFound();
            }
            return View(dataSet);
        }

        // GET: DataSets/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: DataSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,title,description")] DataSet dataSet, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.DataSets.Add(dataSet);

                var userId = User.Identity.GetUserId();
                DataSet data = db.DataSets.Find(dataSet.Id);
                if (data == null)
                {
                    return HttpNotFound();
                }

                
                data.UserId = userId;
                data.file = file;
                var user = db.Users.Include("OwnedData").Single(x => x.Id == userId);
                user.OwnedData.Add(data);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dataSet);
        }

        // GET: DataSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataSet dataSet = db.DataSets.Find(id);
            if (dataSet == null)
            {
                return HttpNotFound();
            }
            return View(dataSet);
        }

        // POST: DataSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,title,description")] DataSet dataSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dataSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dataSet);
        }

        // GET: DataSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataSet dataSet = db.DataSets.Find(id);
            if (dataSet == null)
            {
                return HttpNotFound();
            }
            return View(dataSet);
        }

        public ActionResult DownloadFromQL(int id)
        {
            DataSet temp = db.DataSets.Include("QuestionList").Single(x => x.Id == id);

            ReportsCSVExporter.WriteToCSV(temp.QuestionList);

            return RedirectToAction("Index", "DataSet", new { id = temp.Id });
        }

        // POST: DataSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DataSet dataSet = db.DataSets.Find(id);
            db.DataSets.Remove(dataSet);
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
