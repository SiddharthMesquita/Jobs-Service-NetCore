using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SIM.Jobs.Core.Interfaces.Repositories;
using SIM.Jobs.Core.Interfaces.Repositories.Shared;
using SIM.Jobs.Core.Models.Departments;
using SIM.Jobs.Infrastructure.Repositories.Shared;

namespace SIM.Jobs.Infrastructure.Repositories
{
    public class DepartmentsRepository : RepositoryBase, IDepartmentsRepository
    {
        private const string SprGetDepartments = "Jobs.DepartmentsGet";
        private const string SprUpdateDepartment = "Jobs.DepartmentsUpdate";
        private const string SprCreateDepartment = "Jobs.DepartmentsCreate";
         


        public DepartmentsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

   

         public async Task<int> CreateDepartment(DepartmentsCreateRequest request)
        {
             var parameters = new DynamicParameters();
            parameters.Add("@title", request.title, DbType.String);
            var res = await ExecuteStoredProcedureListResult<string>(SprCreateDepartment, parameters);
            return Convert.ToInt32(res.Response.FirstOrDefault());
        }


        public async Task<int> UpdateDepartment(int departmentId,DepartmentsUpdateRequest request)
        {
               var parameters = new DynamicParameters();
             parameters.Add("@departmentsId", departmentId, DbType.Int32);
            parameters.Add("@title", request.title, DbType.String);

            var res = await ExecuteStoredProcedureListResult<string>(SprUpdateDepartment, parameters);
            return Convert.ToInt32(res.Response.FirstOrDefault());
        }

        public async Task<List<DepartmentsGetRequestResponseData>> GetDepartments( )
        {
            var parameters = new DynamicParameters();
            var res = await ExecuteStoredProcedureListResult<DepartmentsGetRequestResponseData>(SprGetDepartments, parameters);
           
            return   res.Response.ToList();;
        }

      
    }
}