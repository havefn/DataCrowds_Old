using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCrowds.Models
{
    public class DataSet
    {
        public int dataSetId { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public HttpPostedFileBase file { get; set; }

        
    }
}