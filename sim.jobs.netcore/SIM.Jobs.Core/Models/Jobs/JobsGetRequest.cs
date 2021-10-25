using System;
using Newtonsoft.Json;

namespace SIM.Jobs.Core.Models.Jobs
{

    public class JobsGetRequest
    {
         public string searchText { get; set; }
        public int? pageNo { get; set; }
        public int? pageSize { get; set; }
        public int? locationId { get; set; }
        public int? departmentId { get; set; }
    }
}