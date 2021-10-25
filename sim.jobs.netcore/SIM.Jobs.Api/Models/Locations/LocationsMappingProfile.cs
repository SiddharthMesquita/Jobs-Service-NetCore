using AutoMapper;
using SIM.Jobs.Core.Models.Locations;

namespace SIM.Jobs.API.Models.Locations
{
    public class LocationsMappingProfile: Profile {
     public LocationsMappingProfile() {
         // Add as many of these lines as you need to map your objects
        this.CreateMap<LocationsGetRequestResponseData, LocationsGetRequestResponseDto>();
  
        this.CreateMap<LocationsCreateRequestDto, LocationsCreateRequest>();

        this.CreateMap<LocationsUpdateRequestDto, LocationsUpdateRequest>();

        
     }
    }
}