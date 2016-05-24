using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataCrowds.Models;

namespace SurveyTool.Controllers
{
    [Authorize]
    public class SurveysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        
        [HttpGet]
        public ActionResult Index()
        {
            var surveys = db.Surveys.ToList();
            return View(surveys);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var survey = new Survey
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(1)
                };

            return View(survey);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Survey survey, string action)
        {
            if (ModelState.IsValid)
            {
                survey.Questions.ForEach(q => q.CreatedOn = q.ModifiedOn = DateTime.Now);
                db.Surveys.Add(survey);
                db.SaveChanges();
                TempData["success"] = "The survey was successfully created!";
                return RedirectToAction("Edit", new {id = survey.Id});
            }
            else
            {
                TempData["error"] = "An error occurred while attempting to create this survey.";
                return View(survey);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var survey = db.Surveys.Include("Questions").Single(x => x.Id == id);
            survey.Questions = survey.Questions.OrderBy(q => q.Priority).ToList();
            return View(survey);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Survey model)
        {
            foreach (var question in model.Questions)
            {
                question.SurveyId = model.Id;

                if (question.Id == 0)
                {
                    question.CreatedOn = DateTime.Now;
                    question.ModifiedOn = DateTime.Now;
                    db.Entry(question).State = EntityState.Added;
                }
                else
                {
                    question.ModifiedOn = DateTime.Now;
                    db.Entry(question).State = EntityState.Modified;
                    db.Entry(question).Property(x => x.CreatedOn).IsModified = false;
                }
            }

            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Edit", new {id = model.Id});
        }

        [HttpPost]
        public ActionResult Delete(Survey survey)
        {
            db.Entry(survey).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
