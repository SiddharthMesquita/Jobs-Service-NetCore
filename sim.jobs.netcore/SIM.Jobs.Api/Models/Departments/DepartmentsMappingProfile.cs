using AutoMapper;
using SIM.Jobs.Core.Models.Departments;

namespace SIM.Jobs.API.Models.Departments
{
    public class DepartmentsMappingProfile: Profile {
     public DepartmentsMappingProfile() {
      
        this.CreateMap<DepartmentsGetRequestResponseData, DepartmentsGetRequestResponseDto>();
  
        this.CreateMap<DepartmentsCreateRequestDto, DepartmentsCreateRequest>();

        this.CreateMap<DepartmentsUpdateRequestDto, DepartmentsUpdateRequest>();

        
     }
    }
}