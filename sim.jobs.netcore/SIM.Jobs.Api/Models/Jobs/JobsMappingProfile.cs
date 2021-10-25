using AutoMapper;
using SIM.Jobs.Core.Models.Jobs;

namespace SIM.Jobs.API.Models.Jobs
{
    public class JobsMappingProfile: Profile {
     public JobsMappingProfile() {
         // Add as many of these lines as you need to map your objects
        this.CreateMap<JobsGetRequestDto, JobsGetRequest>();
        this.CreateMap<JobsRequestData, JobsRequestDataDto>();

        this.CreateMap<JobsCreateRequestDto, JobsCreateRequest>();

        this.CreateMap<JobsUpdateRequestDto, JobsUpdateRequest>();
        

        
     }
    }
}