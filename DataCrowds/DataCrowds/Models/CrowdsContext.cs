using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataCrowds.Models
{
    public class CrowdsContext : DbContext
    {
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<SurveyForm> SurveyForms { get; set; }

    }
}