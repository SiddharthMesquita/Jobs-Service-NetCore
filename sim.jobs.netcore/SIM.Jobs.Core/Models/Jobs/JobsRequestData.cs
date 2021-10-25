using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SIM.Jobs.Core.Models.Jobs
{
    public class JobsRequestData 
    {
     public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int locationId { get; set; }
        public string Ltitle { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int zip { get; set; }
        public int DepartmentId { get; set; }
        public string Dtitle { get; set; }
        public DateTime postedDate { get; set; }
        public DateTime closingDate { get; set; } 

        
    }
}