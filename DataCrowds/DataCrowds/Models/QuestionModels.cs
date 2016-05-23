using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCrowds.Models
{
    public class Question
    {
        public String question { get; set; }
        public Boolean required { get; set; }
        public String type { get; set; }
        public String answer { get; set; }
    }
}