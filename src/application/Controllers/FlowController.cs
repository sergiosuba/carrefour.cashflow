using cashflow.domain.DTO;
using cashflow.infrastructure.common;
using cashflow.domain.Interface.Service;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;

namespace Cashflow.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowController : ControllerBase
    {
        private readonly IFlowService _flowService;
        private readonly ILogger<FlowController> _logger;

        public FlowController(IFlowService flowService,
                                    ILogger<FlowController> logger)
        {
            _flowService = flowService;
            _logger = logger;
        }

        [HttpPost(nameof(AddAsync))]
        [SwaggerOperation(nameof(AddAsync))]
        [Authorize]
        public async Task<Result<FlowDTO>> AddAsync(FlowDTO flowDTO)
        {
            _logger.LogInformation($"{nameof(AddAsync)} -> Start");

            return await _flowService.AddAsync(flowDTO);
        }

        [HttpPost(nameof(GetAllAsync))]
        [SwaggerOperation(nameof(GetAllAsync))]
        [Authorize]
        public async Task<Result<IEnumerable<FlowDTO>>> GetAllAsync(FlowFilterDTO flowFilterDTO)
        {
            _logger.LogInformation($"{nameof(GetAllAsync)} -> Start");

            return await _flowService.GetAllAsync(flowFilterDTO);
        }

        [HttpGet(nameof(GetByIdAsync))]
        [SwaggerOperation(nameof(GetByIdAsync))]
        [Authorize]
        public async Task<Result<FlowDTO>> GetByIdAsync(string id)
        {
            _logger.LogInformation($"{nameof(GetByIdAsync)} -> Start");

            return await _flowService.GetByIdAsync(id);
        }

        [HttpPut(nameof(UpdateAsync))]
        [SwaggerOperation(nameof(UpdateAsync))]
        [Authorize]
        public async Task<Result<FlowDTO>> UpdateAsync(FlowDTO flowDTO)
        {
            _logger.LogInformation($"{nameof(UpdateAsync)} -> Start");

            return await _flowService.UpdateAsync(flowDTO);
        }

        [HttpDelete(nameof(DeleteAsync))]
        [SwaggerOperation(nameof(DeleteAsync))]
        [Authorize]
        public async Task<Result<FlowDTO>> DeleteAsync(string id)
        {
            _logger.LogInformation($"{nameof(DeleteAsync)} -> Start");

            return await _flowService.DeleteAsync(id);
        }
    }
}