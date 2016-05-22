using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataCrowds.Models
{
    public class ExampleModels
    {
        public String name { get; set; }

        [Key]
        public int ExampleID { get; set; }
    }

    

}