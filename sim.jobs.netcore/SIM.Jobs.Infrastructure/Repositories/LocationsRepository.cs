using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SIM.Jobs.Core.Interfaces.Repositories;
using SIM.Jobs.Core.Interfaces.Repositories.Shared;
using SIM.Jobs.Core.Models.Locations;
using SIM.Jobs.Infrastructure.Repositories.Shared;

namespace SIM.Jobs.Infrastructure.Repositories
{
    public class LocationsRepository : RepositoryBase, ILocationsRepository
    {
        private const string SprGetLocations = "Jobs.LocationsGet";
        private const string SprUpdateLocation = "Jobs.LocationsUpdate";
        private const string SprCreateLocation = "Jobs.LocationsCreate";
         


        public LocationsRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

   

         public async Task<int> CreateLocation(LocationsCreateRequest request)
        {
             var parameters = new DynamicParameters();
            parameters.Add("@title", request.title, DbType.String);
            parameters.Add("@city", request.city, DbType.String);
            parameters.Add("@country", request.country, DbType.String);
            parameters.Add("@state", request.state, DbType.String);
            parameters.Add("@zip", request.zip, DbType.String);
            var res = await ExecuteStoredProcedureListResult<string>(SprCreateLocation, parameters);
            return Convert.ToInt32(res.Response.FirstOrDefault());
        }


        public async Task<int> UpdateLocation(int locationId,LocationsUpdateRequest request)
        {
               var parameters = new DynamicParameters();
             parameters.Add("@locationId", locationId, DbType.Int32);
            parameters.Add("@title", request.title, DbType.String);
            parameters.Add("@city", request.city, DbType.String);
            parameters.Add("@country", request.country, DbType.String);
            parameters.Add("@state", request.state, DbType.String);
            parameters.Add("@zip", request.zip, DbType.String);
            var res = await ExecuteStoredProcedureListResult<string>(SprUpdateLocation, parameters);
            return Convert.ToInt32(res.Response.FirstOrDefault());
        }

        public async Task<List<LocationsGetRequestResponseData>> GetLocations( )
        {
            var parameters = new DynamicParameters();
            var res = await ExecuteStoredProcedureListResult<LocationsGetRequestResponseData>(SprGetLocations, parameters);
           
            return   res.Response.ToList();;
        }

      
    }
}