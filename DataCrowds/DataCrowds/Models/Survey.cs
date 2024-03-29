﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataCrowds.Models
{
    public class Survey
    {
        public Survey()
        {
            Questions = new List<Question>();
            Responses = new List<Response>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string UserId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual List<Question> Questions { get; set; }

        public virtual List<Response>  Responses { get; set; }

        public bool IsActive
        {
            get { return StartDate < DateTime.Now && EndDate > DateTime.Now; }
        }

        public string ToJson()
        {
            var js = JsonSerializer.Create(new JsonSerializerSettings());
            var jw = new StringWriter();
            js.Serialize(jw, this);
            return jw.ToString();            
        }
    }
}