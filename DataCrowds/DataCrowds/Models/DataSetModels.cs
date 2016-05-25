using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DataCrowds.Models
{
    public class DataSet
    {
        public HttpPostedFileBase file;

        public int Id { get; set; }

        public string UserId { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public List<QuestionViewModel> QuestionList { get; set; }

        [NotMapped]
        public HttpPostedFileBase file { get; set; }

        
    }
}