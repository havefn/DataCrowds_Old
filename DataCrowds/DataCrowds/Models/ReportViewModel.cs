﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataCrowds.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace DataCrowds.Models
{
    public class ReportViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Survey Survey { get; set; }
        public List<QuestionViewModel> Responses { get; set; }

        [NotMapped]
        public HttpPostedFileBase file { get; set; }
    }

    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Type { get; set; }
        public virtual List<Answer> Answers { get; set; }

        public int Score
        {
           get
           {
               if (Type == "Yes/No")
                   return Answers.Sum(x => x.Value == "Yes" ? 1 : 0);

               if (Type == "Number")
               {
                   return Answers.Sum(x =>
                       {
                           int num;
                           Int32.TryParse(x.Value, out num);
                           return num;
                       });
               }

               return 0;
           }
        }

        public int Total
        {
            get { return Answers.Count(); }
        }

        public double Percentage
        {
            get { return (double)Score / (double)Total; }
        }

        public string PercentageString
        {
            get { return Answers.Any() ? String.Concat((Int32) (Percentage*100), "%") : "0%"; }
        }
    }
}