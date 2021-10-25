using System;
using Newtonsoft.Json;

namespace SIM.Jobs.Core.Models.Jobs
{
    public class JobsGetRequestResponseData 
    {
       public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string location { get; set; }
        public string department { get; set; }
        public DateTime postedDate { get; set; }
        public DateTime closingDate { get; set; } 

        
    }
}