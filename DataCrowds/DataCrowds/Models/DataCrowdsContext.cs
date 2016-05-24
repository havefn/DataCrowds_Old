﻿using SurveyTool.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataCrowds.Models
{
    public class DataCrowdsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DataCrowdsContext() : base("name=DataCrowdsContext")
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Answer> Answers { get; set; }
        

    }
}
