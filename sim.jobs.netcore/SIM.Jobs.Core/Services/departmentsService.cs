using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SIM.Jobs.Core.Interfaces.Repositories;
using SIM.Jobs.Core.Interfaces.Services;
using SIM.Jobs.Core.Models.Departments;

namespace SIM.Jobs.Core.Services
{
    public class DepartmentsService : IDepartmentsService
    {
        private IDepartmentsRepository _departmentsRepository;

        /// <summary>
        /// UserService
        /// </summary>
        /// <param name="userRepository"></param>
        /// <returns></returns>
        public DepartmentsService(IDepartmentsRepository departmentsRepository) 
        {
            _departmentsRepository = departmentsRepository ?? throw new ArgumentNullException(nameof(departmentsRepository));
        }

       

         public async Task<int> CreateDepartment(DepartmentsCreateRequest request)
        {
            return await _departmentsRepository.CreateDepartment(request);
        }

        public async Task<int> UpdateDepartment(int departmentId,DepartmentsUpdateRequest request)
        {
            return await _departmentsRepository.UpdateDepartment(departmentId,request);
        }

        public async Task<List<DepartmentsGetRequestResponseData>> GetDepartments()
        {
             return await _departmentsRepository.GetDepartments();
        }


       
    }
}