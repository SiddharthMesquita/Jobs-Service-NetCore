using System.Collections.Generic;
using System.Threading.Tasks;
using SIM.Jobs.Core.Models.Locations;

namespace SIM.Jobs.Core.Interfaces.Repositories
{
    public interface ILocationsRepository 
    {

        Task<List<LocationsGetRequestResponseData>> GetLocations();
        Task<int> CreateLocation(LocationsCreateRequest request);
        Task<int> UpdateLocation(int locationId,LocationsUpdateRequest request);
    }
}