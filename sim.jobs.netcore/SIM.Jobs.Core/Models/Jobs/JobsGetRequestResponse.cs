using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SIM.Jobs.Core.Models.Jobs
{
    public class JobsGetRequestResponse 
    {
       public int total { get; set; }
       public List<JobsGetRequestResponseData> data { get; set; }

        
    }
}