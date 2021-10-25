using System;

namespace SIM.Jobs.API.Models.Jobs
{
    public class JobsUpdateRequestDto
    {

        public string title { get; set; }
        public string description { get; set; }
        public int locationId { get; set; }
        public int departmentId { get; set; }

        public DateTime? closingDate { get; set; }

    }
}