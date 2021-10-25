using System;
using System.Collections.Generic;
using SIM.Jobs.Core.Models.Jobs;

namespace SIM.Jobs.API.Models.Jobs
{
    public class JobsRequestDataDto
    {
        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public LocationData location { get; set; }
        public DepartmentData department { get; set; }
        public DateTime postedDate { get; set; }
        public DateTime closingDate { get; set; }
    }


    public class LocationData
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int zip { get; set; }
    }

    public class DepartmentData
    {
       public int Id { get; set; }
        public string title { get; set; }
    }
}