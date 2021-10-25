using System.Collections.Generic;
using System.Threading.Tasks;
using SIM.Jobs.Core.Models.Departments;

namespace SIM.Jobs.Core.Interfaces.Services
{
    public interface IDepartmentsService
    {

        Task<List<DepartmentsGetRequestResponseData>> GetDepartments();
        Task<int> CreateDepartment(DepartmentsCreateRequest request);
        Task<int> UpdateDepartment(int departmentId,DepartmentsUpdateRequest request);
     
    }
}