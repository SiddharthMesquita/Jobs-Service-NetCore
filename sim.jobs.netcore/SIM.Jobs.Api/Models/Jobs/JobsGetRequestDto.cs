using System;
using System.ComponentModel.DataAnnotations;

namespace SIM.Jobs.API.Models.Jobs
{
    public class JobsGetRequestDto
    {
        [Required]
        public string searchText { get; set; }
        [Required]
        public int? pageNo { get; set; }
        [Required]
        public int? pageSize { get; set; }
        public int? locationId { get; set; }
        public int? departmentId { get; set; }

    }
}