using System.Collections.Generic;
using SIM.Jobs.Core.Models.Jobs;

namespace SIM.Jobs.API.Models.Jobs
{
    public class JobsGetResponseDto 
    {
       public int total { get; set; }

       public List<JobsGetRequestResponseData> data { get; set; }
    }
}