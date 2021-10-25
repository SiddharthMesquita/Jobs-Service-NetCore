using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SIM.Jobs.Core.Interfaces.Repositories;
using SIM.Jobs.Core.Interfaces.Services;
using SIM.Jobs.Core.Models.Jobs;

namespace SIM.Jobs.Core.Services
{
    public class JobsService : IJobsService
    {
        private IJobsRepository _jobsRepository;

        /// <summary>
        /// UserService
        /// </summary>
        /// <param name="userRepository"></param>
        /// <returns></returns>
        public JobsService(IJobsRepository jobsRepository) 
        {
            _jobsRepository = jobsRepository ?? throw new ArgumentNullException(nameof(jobsRepository));
        }

       

        // public Task<UnconfirmedAuthUser> AddNewAuthUser(UnconfirmedAuthUser authUser)
        // {
        //     throw new NotImplementedException();
        // }

         public async Task<JobsRequestData> GetJob(int request)
        {
            return await _jobsRepository.GetJob(request);
        }


        public async Task<JobsGetRequestResponse> GetAllJobs(JobsGetRequest request)
        {
            return await _jobsRepository.GetAllJobs(request);
        }

         public async Task<int> CreateJob(JobsCreateRequest request)
        {
            return await _jobsRepository.CreateJob(request);
        }

        public async Task<int> UpdateJob(int jobId,JobsUpdateRequest request)
        {
            return await _jobsRepository.UpdateJob(jobId,request);
        }


        // public async Task<List<AuthUser>> GetAllRegisteredUsers()
        // {
        //     return await _userRepository.All() as List<AuthUser>;
        // }

        // public async Task<AuthUser> GetUserById(int id)
        // {
        //      return await _userRepository.GetById(id) as AuthUser;
        // }
    }
}