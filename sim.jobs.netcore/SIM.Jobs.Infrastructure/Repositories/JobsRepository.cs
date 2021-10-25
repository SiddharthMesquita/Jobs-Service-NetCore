using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SIM.Jobs.Core.Interfaces.Repositories;
using SIM.Jobs.Core.Interfaces.Repositories.Shared;
using SIM.Jobs.Core.Models.Jobs;
using SIM.Jobs.Infrastructure.Repositories.Shared;

namespace SIM.Jobs.Infrastructure.Repositories
{
    public class JobsRepository : RepositoryBase, IJobsRepository
    {
        private const string SprGetJobs = "Jobs.JobsGet";
        private const string SprCreateJob = "Jobs.JobsCreate";
        private const string SprGetJob = "Jobs.JobsDetailGet";
        private const string SprUpdateJob = "Jobs.JobsUpdate";
         


        public JobsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

       

    

        public async Task<JobsGetRequestResponse> GetAllJobs(JobsGetRequest request)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@searchText", request.searchText, DbType.String);
            parameters.Add("@pageNo", request.pageNo, DbType.Int32);
            parameters.Add("@pageSize", request.pageSize, DbType.Int32);
            parameters.Add("@locationId", request.locationId, DbType.Int32);
            parameters.Add("@departmentId", request.departmentId, DbType.Int32);
            parameters.Add("@total", ParameterDirection.Output, DbType.Int32);
            var res = await ExecuteStoredProcedureListResult<JobsGetRequestResponseData>(SprGetJobs, parameters);
            JobsGetRequestResponse response = new JobsGetRequestResponse();
            response.data = res.Response.ToList();
            response.total = parameters.Get<int>("@total");
            return response;
        }

         public async Task<int> CreateJob(JobsCreateRequest request)
        {
             var parameters = new DynamicParameters();
            parameters.Add("@title", request.title, DbType.String);
            parameters.Add("@description", request.description, DbType.String);
            parameters.Add("@locationId", request.locationId, DbType.Int32);
            parameters.Add("@departmentId", request.departmentId, DbType.Int32);
            parameters.Add("@code","JOB-"+DateTime.Now.ToString("MMddyyyyhhmmsstt"), DbType.String);
            parameters.Add("@closingDate", request.closingDate, DbType.DateTime);
            parameters.Add("@postedDate", DateTime.Now , DbType.DateTime);
            var res = await ExecuteStoredProcedureListResult<string>(SprCreateJob, parameters);
            return Convert.ToInt32(res.Response.FirstOrDefault());
        }

        public async Task<JobsRequestData> GetJob(int request)
        {
             var parameters = new DynamicParameters();
            parameters.Add("@jobId", request, DbType.Int32);
            var res = await ExecuteStoredProcedureListResult<JobsRequestData>(SprGetJob, parameters);
            return res.Response.FirstOrDefault();
        }

        public async Task<int> UpdateJob(int jobId,JobsUpdateRequest request)
        {
               var parameters = new DynamicParameters();
               parameters.Add("@jobId", jobId, DbType.Int32);
            parameters.Add("@title", request.title, DbType.String);
            parameters.Add("@description", request.description, DbType.String);
            parameters.Add("@locationId", request.locationId, DbType.Int32);
            parameters.Add("@departmentId", request.departmentId, DbType.Int32);
            parameters.Add("@closingDate", request.closingDate, DbType.DateTime);

            var res = await ExecuteStoredProcedureListResult<string>(SprUpdateJob, parameters);
            return Convert.ToInt32(res.Response.FirstOrDefault());
        }

        // public async Task<AuthUser> GetById(int id)
        // {
        //     var parameters = new DynamicParameters();
        //     parameters.Add("@Id", id, DbType.Int32);
        //     var res = await ExecuteStoredProcedureListResult<AuthUser>(SprGetUserById, parameters);
        //     return res.Response.FirstOrDefault() as AuthUser;
        // }

        // public async Task<List<UnconfirmedAuthUser>> GetUnConfirmedUsers()
        // {
        //     var parameters = new DynamicParameters();
        //     var res = await ExecuteStoredProcedureListResult<UnconfirmedAuthUser>(SprGetUnconfirmedUsers, parameters);
        //     return res.Response as List<UnconfirmedAuthUser>;
        // }

        // public async Task<UnconfirmedAuthUser> GetUnConfirmedUsersById(int Id)
        // {
        //     var parameters = new DynamicParameters();
        //     parameters.Add("@Id", DbType.Int32);
        //     var res = await ExecuteStoredProcedureListResult<UnconfirmedAuthUser>(SprGetUnconfirmedUserById, parameters);
        //     return res.Response.FirstOrDefault() as UnconfirmedAuthUser;
        // }

        // public async Task<bool> Upsert(AuthUser entity)
        // {
        //     if (entity is null)
        //     {
        //         throw new ArgumentNullException(nameof(entity));
        //     }

        //     var parameters = new DynamicParameters();
        //     parameters.Add("@FirstName", entity.FirstName, dbType: DbType.String);
        //     parameters.Add("@LastName", entity.LastName, dbType: DbType.String);
        //     parameters.Add("@Email", entity.Email, dbType: DbType.String);
        //     parameters.Add("@Username", entity.Username, dbType: DbType.String);
        //     parameters.Add("@Phone", entity.Phone, dbType: DbType.Int64);
        //     var res = await ExecuteStoredProcedureUpdateDeleteResult(SprUpdateConfirmedUser, parameters);
        //     if (res > 0)
        //         return true;
        //     else
        //         return false;
        // }
    }
}