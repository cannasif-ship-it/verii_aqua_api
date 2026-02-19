using aqua_api.DTOs;
using aqua_api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace aqua_api.Controllers.AquaController
{
    [ApiController]
    [Route("api/aqua/WeighingLine")]
    [Authorize]
    public class WeighingLineController : ControllerBase
    {
        private readonly IWeighingLineService _service;

        public WeighingLineController(IWeighingLineService service)
        {
            _service = service;
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ApiResponse<WeighingLineDto>>> GetById(long id, CancellationToken cancellationToken)
        {
            var result = await _service.GetByIdAsync(id);
            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<PagedResponse<WeighingLineDto>>>> GetAll([FromQuery] PagedRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAllAsync(request);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<WeighingLineDto>>> Create([FromBody] CreateWeighingLineDto dto, CancellationToken cancellationToken)
        {            var result = await _service.CreateAsync(dto);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<ApiResponse<WeighingLineDto>>> Update(long id, [FromBody] UpdateWeighingLineDto dto, CancellationToken cancellationToken)
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
