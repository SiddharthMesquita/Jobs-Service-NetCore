using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIM.Jobs.API.Models.Jobs;
using SIM.Jobs.Core.Interfaces.Services;
using SIM.Jobs.Core.Models.Jobs;
using SIM.Jobs.Core.Models.Shared;

namespace SIM.Jobs.API.Controllers
{
    /// <summary>
    /// JobsController
    /// </summary>
    [ApiController]
    [Route("v1")]
    public class JobsController : ControllerBase
    {
        private readonly IJobsService _jobsService;
        private readonly IMapper _mapper;
      
        /// <summary>
        /// AuthJobsController
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="authuserService"></param>
        /// <param name="mapper"></param>
        /// <param name="emailSender"></param>
        public JobsController( IJobsService jobsService, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jobsService = jobsService ?? throw new ArgumentNullException(nameof(jobsService));
        }


  /// <summary>
        /// Create Job
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(JobsRequestDataDto),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        // [Authorize]
        [HttpGet("jobs/{jobId:int:min(1)}")]
        public async Task<ActionResult<int>> GetJob([FromRoute] int jobId)
        {
       
            var res = await _jobsService.GetJob(jobId);
            var responseDto = _mapper.Map<JobsRequestDataDto>(res);

            responseDto.location = new LocationData(){
                Id = res.locationId,
                title = res.Ltitle,
                city = res.city,
                state = res.state,
                country = res.country,
                zip = res.zip
            };
            responseDto.department = new DepartmentData(){
                Id = res.DepartmentId,
                title = res.Dtitle
            };
            return Ok(responseDto);
        }

        /// <summary>
        /// GetAll Jobs
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<JobsGetResponseDto>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        // [Authorize]
        [HttpPost("jobs/list")]
        public async Task<ActionResult<JobsGetResponseDto>> GetAllJobs(JobsGetRequestDto request)
        {
             var model = _mapper.Map<JobsGetRequest>(request);
            var res = await _jobsService.GetAllJobs(model);
            var finalResponse = new JobsGetResponseDto();
            finalResponse.total = res.total;
            finalResponse.data = res.data;
            return Ok(finalResponse);
        }

         /// <summary>
        /// Create Job
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        // [Authorize]
        [HttpPost("jobs")]
        public async Task<ActionResult<int>> CreateJob(JobsCreateRequestDto request)
        {
             var model = _mapper.Map<JobsCreateRequest>(request);
            var res = await _jobsService.CreateJob(model);
             return CreatedAtAction(nameof(GetJob), new { jobId = res }, res);
        }

          /// <summary>
        /// Create Job
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        // [Authorize]
        [HttpPut("jobs/{jobId:int:min(1)}")]
        public async Task<ActionResult<int>> UpdateJob([FromRoute] int jobId, JobsUpdateRequestDto request)
        {
             var model = _mapper.Map<JobsUpdateRequest>(request);
            var res = await _jobsService.UpdateJob(jobId,model);
             return Ok();
        }
       
       
    }
}
