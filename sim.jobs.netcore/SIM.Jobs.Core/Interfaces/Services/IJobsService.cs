using System.Threading.Tasks;
using SIM.Jobs.Core.Models.Jobs;

namespace SIM.Jobs.Core.Interfaces.Services
{
    public interface IJobsService
    {

        Task<JobsRequestData> GetJob(int request);
        Task<JobsGetRequestResponse> GetAllJobs(JobsGetRequest request);
        Task<int> CreateJob(JobsCreateRequest request);
        Task<int> UpdateJob(int jobId,JobsUpdateRequest request);
        
    }
}