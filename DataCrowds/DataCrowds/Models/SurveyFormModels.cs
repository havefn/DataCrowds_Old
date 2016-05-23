using DataCrowds.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCrowds.Models
{
    public class SurveyForm
    {
        public List<Question> questionList { get; set; }
        public String category { get; set; }
        public int maxRespondents { get; set; }
        public String rewards { get; set; }
        public int surveyFormId { get; set; }
    }
}