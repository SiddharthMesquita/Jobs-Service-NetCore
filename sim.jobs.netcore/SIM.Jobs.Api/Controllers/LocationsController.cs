using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIM.Jobs.API.Models.Locations;
using SIM.Jobs.Core.Interfaces.Services;
using SIM.Jobs.Core.Models.Locations;
using SIM.Jobs.Core.Models.Shared;

namespace SIM.Jobs.API.Controllers
{
    /// <summary>
    /// LocationsController
    /// </summary>
    [ApiController]
    [Route("v1")]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsService _locationsService;
        private readonly IMapper _mapper;
      
        /// <summary>
        /// AuthLocationsController
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="authuserService"></param>
        /// <param name="mapper"></param>
        /// <param name="emailSender"></param>
        public LocationsController( ILocationsService locationsService, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _locationsService = locationsService ?? throw new ArgumentNullException(nameof(locationsService));
        }



        /// <summary>
        /// GetAll Locations
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<LocationsGetRequestResponseDto>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        // [Authorize]
        [HttpGet("locations")]
        public async Task<ActionResult<LocationsGetRequestResponseDto>> GetAllLocations()
        {
           
            var res = await _locationsService.GetLocations();
            var model = _mapper.Map<List<LocationsGetRequestResponseDto>>(res);
            return Ok(model);
        }

         /// <summary>
        /// Create Location
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        // [Authorize]
        [HttpPost("locations")]
        public async Task<ActionResult<int>> CreateLocation(LocationsCreateRequestDto request)
        {
             var model = _mapper.Map<LocationsCreateRequest>(request);
            var res = await _locationsService.CreateLocation(model);
             return Ok(res);
        }

          /// <summary>
        /// Create Location
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        // [Authorize]
        [HttpPut("locations/{locationId:int:min(1)}")]
        public async Task<ActionResult<int>> UpdateLocation([FromRoute] int locationId, LocationsUpdateRequestDto request)
        {
             var model = _mapper.Map<LocationsUpdateRequest>(request);
            var res = await _locationsService.UpdateLocation(locationId,model);
             return Ok();
        }
      
       
    }
}
