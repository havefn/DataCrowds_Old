using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCrowds.Models
{
    public class Question
    {
        public int Id { get; set; }

        public Boolean required { get; set; }

        public string type { get; set; }

        public string answer { get; set; }
    }
}