using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurveyTool.Models;
using DataCrowds.Models;

namespace SurveyTool.Controllers
{
    [Authorize]
    public class ResponsesController : Controller
    {
        private DataCrowdsContext db = new DataCrowdsContext();

        [HttpGet]
        public ActionResult Index(int surveyId)
        {
            var responses = db.Responses
                               .Include("Survey")
                               .Include("Answers")
                               .Include("Answers.Question")
                               .Where(x => x.SurveyId == surveyId)
                               .Where(x => x.CreatedBy == User.Identity.Name)
                               .OrderByDescending(x => x.CreatedOn)
                               .ThenByDescending(x => x.Id)
                               .ToList();

            return View(responses);
        }

        [HttpGet]
        public ActionResult Details(int surveyId, int id)
        {
            var response = db.Responses
                              .Include("Survey")
                              .Include("Answers")
                              .Include("Answers.Question")
                              .Where(x => x.SurveyId == surveyId)
                              .Where(x => x.CreatedBy == User.Identity.Name)
                              .Single(x => x.Id == id);

            response.Answers = response.Answers.OrderBy(x => x.Question.Priority).ToList();
            return View(response);
        }

        [HttpGet]
        public ActionResult Create(int surveyId)
        {
            var survey = db.Surveys
                            .Where(s => s.Id == surveyId)
                            .Select(s => new
                                {
                                    Survey = s,
                                    Questions = s.Questions
                                                 .Where(q => q.IsActive)
                                                 .OrderBy(q => q.Priority)
                                })
                             .AsEnumerable()
                             .Select(x =>
                                 {
                                     x.Survey.Questions = x.Questions.ToList();
                                     return x.Survey;
                                 })
                             .Single();

            return View(survey);
        }

        [HttpPost]
        public ActionResult Create(int surveyId, string action, Response model)
        {
            model.Answers = model.Answers.Where(a => !String.IsNullOrEmpty(a.Value)).ToList();
            model.SurveyId = surveyId;
            model.CreatedBy = User.Identity.Name;
            model.CreatedOn = DateTime.Now;
            db.Responses.Add(model);
            db.SaveChanges();

            TempData["success"] = "Your response was successfully saved!";

            return action == "Next"
                       ? RedirectToAction("Create", new {surveyId})
                       : RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Delete(int surveyId, int id, string returnTo)
        {
            var response = new Response() { Id = id, SurveyId = surveyId };
            db.Entry(response).State = EntityState.Deleted;
            db.SaveChanges();
            return Redirect(returnTo ?? Url.RouteUrl("Root"));
        }
    }
}