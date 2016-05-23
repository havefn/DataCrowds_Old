using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataCrowds.Models
{
    public class Profile
    {
        
        public int Id { get; set; }

        public DateTime birthDate { set; get; }

        public string occupation { get; set; }

        public string gender { get; set; }
        
    }
}