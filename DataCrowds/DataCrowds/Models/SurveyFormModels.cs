﻿using DataCrowds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCrowds.Models
{
    public class SurveyForm
    {
        public int Id { get; set; }

        List<Question> QuestionList { get; set; }

        public string category { get; set; }

        public int maxRespondents { get; set; }

        public string rewards { get; set; }

        public int surveyFormId { get; set; }
    }
}