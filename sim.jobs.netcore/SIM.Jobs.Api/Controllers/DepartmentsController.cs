using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIM.Jobs.API.Models.Departments;
using SIM.Jobs.Core.Interfaces.Services;
using SIM.Jobs.Core.Models.Departments;
using SIM.Jobs.Core.Models.Shared;

namespace SIM.Jobs.API.Controllers
{
    /// <summary>
    /// DepartmentsController
    /// </summary>
    [ApiController]
    [Route("v1")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentsService _departmentsService;
        private readonly IMapper _mapper;
      
        /// <summary>
        /// AuthDepartmentsController
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="authuserService"></param>
        /// <param name="mapper"></param>
        /// <param name="emailSender"></param>
        public DepartmentsController( IDepartmentsService departmentsService, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _departmentsService = departmentsService ?? throw new ArgumentNullException(nameof(departmentsService));
        }



        /// <summary>
        /// GetAll Departments
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<DepartmentsGetRequestResponseDto>),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        // [Authorize]
        [HttpGet("departments")]
        public async Task<ActionResult<DepartmentsGetRequestResponseDto>> GetAllDepartments()
        {
           
            var res = await _departmentsService.GetDepartments();
            var model = _mapper.Map<List<DepartmentsGetRequestResponseDto>>(res);
            return Ok(model);
        }

         /// <summary>
        /// Create Department
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        // [Authorize]
        [HttpPost("departments")]
        public async Task<ActionResult<int>> CreateDepartment(DepartmentsCreateRequestDto request)
        {
             var model = _mapper.Map<DepartmentsCreateRequest>(request);
            var res = await _departmentsService.CreateDepartment(model);
             return Ok(res);
        }

          /// <summary>
        /// Create Department
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(int),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorDetails), StatusCodes.Status404NotFound)]
        // [Authorize]
        [HttpPut("departments/{departmentId:int:min(1)}")]
        public async Task<ActionResult<int>> UpdateDepartment([FromRoute] int departmentId, DepartmentsUpdateRequestDto request)
        {
             var model = _mapper.Map<DepartmentsUpdateRequest>(request);
            var res = await _departmentsService.UpdateDepartment(departmentId,model);
             return Ok();
        }
      
       
    }
}
