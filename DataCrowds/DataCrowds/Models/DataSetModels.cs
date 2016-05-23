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
        public int Id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        [NotMapped]
        public HttpPostedFileBase file { get; set; }        
    }
}