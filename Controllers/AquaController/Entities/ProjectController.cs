using aqua_api.DTOs;
using aqua_api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aqua_api.Controllers.AquaController
{
    [ApiController]
    [Route("api/aqua/Project")]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ApiResponse<ProjectDto>>> GetById(long id, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResponse<ProjectDto>>>> GetAll([FromQuery] PagedRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAllAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<ProjectDto>>> Create([FromBody] CreateProjectDto dto, CancellationToken cancellationToken)
        {            var result = await _service.CreateAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<ApiResponse<ProjectDto>>> Update(long id, [FromBody] UpdateProjectDto dto, CancellationToken cancellationToken)
        {            var result = await _service.UpdateAsync(id, dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<ApiResponse<bool>>> Delete(long id, CancellationToken cancellationToken)
        {            var result = await _service.SoftDeleteAsync(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
