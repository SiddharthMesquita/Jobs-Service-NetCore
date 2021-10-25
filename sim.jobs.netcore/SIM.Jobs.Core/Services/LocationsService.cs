using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SIM.Jobs.Core.Interfaces.Repositories;
using SIM.Jobs.Core.Interfaces.Services;
using SIM.Jobs.Core.Models.Locations;

namespace SIM.Jobs.Core.Services
{
    public class LocationsService : ILocationsService
    {
        private ILocationsRepository _locationsRepository;

        /// <summary>
        /// UserService
        /// </summary>
        /// <param name="userRepository"></param>
        /// <returns></returns>
        public LocationsService(ILocationsRepository locationsRepository) 
        {
            _locationsRepository = locationsRepository ?? throw new ArgumentNullException(nameof(locationsRepository));
        }

       

         public async Task<int> CreateLocation(LocationsCreateRequest request)
        {
            return await _locationsRepository.CreateLocation(request);
        }

        public async Task<int> UpdateLocation(int locationId,LocationsUpdateRequest request)
        {
            return await _locationsRepository.UpdateLocation(locationId,request);
        }

        public async Task<List<LocationsGetRequestResponseData>> GetLocations()
        {
             return await _locationsRepository.GetLocations();
        }


       
    }
}