using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DataCrowds.Models
{
    public class SurveyFormsController : Controller
    {
        private DataCrowdsContext db = new DataCrowdsContext();

        // GET: SurveyForms
        public ActionResult Index()
        {
            return View(db.SurveyForms.ToList());
        }

        // GET: SurveyForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyForm surveyForm = db.SurveyForms.Find(id);
            if (surveyForm == null)
            {
                return HttpNotFound();
            }
            return View(surveyForm);
        }

        // GET: SurveyForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SurveyForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,category,maxRespondents,rewards,surveyFormId")] SurveyForm surveyForm)
        {
            if (ModelState.IsValid)
            {
                db.SurveyForms.Add(surveyForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(surveyForm);
        }

        // GET: SurveyForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyForm surveyForm = db.SurveyForms.Find(id);
            if (surveyForm == null)
            {
                return HttpNotFound();
            }
            return View(surveyForm);
        }

        // POST: SurveyForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,category,maxRespondents,rewards,surveyFormId")] SurveyForm surveyForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surveyForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(surveyForm);
        }

        // GET: SurveyForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SurveyForm surveyForm = db.SurveyForms.Find(id);
            if (surveyForm == null)
            {
                return HttpNotFound();
            }
            return View(surveyForm);
        }

        // POST: SurveyForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SurveyForm surveyForm = db.SurveyForms.Find(id);
            db.SurveyForms.Remove(surveyForm);
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
