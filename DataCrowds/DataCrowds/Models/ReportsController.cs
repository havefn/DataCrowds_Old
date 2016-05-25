using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataCrowds.Models;
using System.Text;

namespace SurveyTool.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        [HttpGet]
        public ActionResult Index()
        {
            var surveys = db.Surveys.ToList();
            return View(surveys);
        }

        [HttpGet]
        public ActionResult Details(int id, int? departmentId, DateTime? startDate, DateTime? endDate)
        {
            var questions = new List<QuestionViewModel>();
            startDate = startDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            endDate = endDate ?? DateTime.Now;

            var survey = db.Surveys.Single(s => s.Id == id);

            db.Questions
               .Where(q => q.SurveyId == id)
               .OrderBy(q => q.Priority)
               .Select(q => new
               {
                   q.Title,
                   q.Body,
                   q.Type,
                   Answers = db.Answers.Where(a => a.QuestionId == q.Id &&
                                                    a.Response.CreatedOn >= startDate.Value &&
                                                    a.Response.CreatedOn <= endDate.Value)
               })
               .ToList()
               .ForEach(r => questions.Add(new QuestionViewModel
               {
                   Title = r.Title,
                   Body = r.Body,
                   Type = r.Type,
                   Answers = r.Answers.ToList()
               }));

            var vm = new ReportViewModel
            {
                StartDate = startDate.Value,
                EndDate = endDate.Value,
                Survey = survey,
                Responses = questions
            };

            return View(vm);
        }

        public ActionResult DownloadReports(int id, int? departmentId, DateTime? startDate, DateTime? endDate)
        {
            var questions = new List<QuestionViewModel>();
            startDate = startDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            endDate = endDate ?? DateTime.Now;

            var survey = db.Surveys.Single(s => s.Id == id);

            db.Questions
               .Where(q => q.SurveyId == id)
               .OrderBy(q => q.Priority)
               .Select(q => new
               {
                   q.Title,
                   q.Body,
                   q.Type,
                   Answers = db.Answers.Where(a => a.QuestionId == q.Id &&
                                                    a.Response.CreatedOn >= startDate.Value &&
                                                    a.Response.CreatedOn <= endDate.Value)
               })
               .ToList()
               .ForEach(r => questions.Add(new QuestionViewModel
               {
                   Title = r.Title,
                   Body = r.Body,
                   Type = r.Type,
                   Answers = r.Answers.ToList()
               }));

            ReportsCSVExporter.WriteToCSV(questions);

            var vm = new ReportViewModel
            {
                StartDate = startDate.Value,
                EndDate = endDate.Value,
                Survey = survey,
                Responses = questions
            };

            return View(vm);
        }


    }

    public class ReportsCSVExporter
    {


        public static void WriteToCSV(List<QuestionViewModel> QuestionList)
        {
            
            string attachment = "attachment; filename=Reports.csv";
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", attachment);
            HttpContext.Current.Response.ContentType = "text/csv";
            HttpContext.Current.Response.AddHeader("Pragma", "public");
            WriteColumnName();
            foreach (QuestionViewModel question in QuestionList)
            {
                WriteQuestionInfo(question);
            }
            HttpContext.Current.Response.End();
        }

        private static void WriteQuestionInfo(QuestionViewModel Question)
        {
            StringBuilder stringBuilder = new StringBuilder();
            AddComma(Question.Title, stringBuilder);
            AddComma(Question.Type, stringBuilder);
            AddComma(Question.Body, stringBuilder);
            AddComma(Question.Score.ToString(), stringBuilder);
            AddComma(Question.Total.ToString(), stringBuilder);
            AddComma(Question.PercentageString, stringBuilder);
            HttpContext.Current.Response.Write(stringBuilder.ToString());
            HttpContext.Current.Response.Write(Environment.NewLine);
        }

        private static void AddComma(string value, StringBuilder stringBuilder)
        {
            stringBuilder.Append(value.Replace(',', ' '));
            stringBuilder.Append(", ");
        }

        private static void WriteColumnName()
        {
            string columnNames = "Title, Type, Body, Score, Total, Percentage/Average";
            HttpContext.Current.Response.Write(columnNames);
            HttpContext.Current.Response.Write(Environment.NewLine);
        }
    }
}
