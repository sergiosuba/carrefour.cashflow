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
    public class ChartAccountController : ControllerBase
    {
        private readonly IChartAccountService _chartAccountService;
        private readonly ILogger<ChartAccountController> _logger;

        public ChartAccountController(IChartAccountService chartAccountService,
                                    ILogger<ChartAccountController> logger)
        {
            _chartAccountService = chartAccountService;
            _logger = logger;
        }

        [HttpPost(nameof(AddAsync))]
        [SwaggerOperation(nameof(AddAsync))]
        [Authorize]
        public async Task<Result<ChartAccountDTO>> AddAsync(ChartAccountDTO chartAccountDTO)
        {
            _logger.LogInformation($"{nameof(AddAsync)} -> Start");

            return await _chartAccountService.AddAsync(chartAccountDTO);
        }

        [HttpPost(nameof(GetAllAsync))]
        [SwaggerOperation(nameof(GetAllAsync))]
        [Authorize]
        public async Task<Result<IEnumerable<ChartAccountDTO>>> GetAllAsync(ChartAccountFilterDTO chartAccountFilterDTO)
        {
            _logger.LogInformation($"{nameof(GetAllAsync)} -> Start");

            return await _chartAccountService.GetAllAsync(chartAccountFilterDTO);
        }

        [HttpGet(nameof(GetByIdAsync))]
        [SwaggerOperation(nameof(GetByIdAsync))]
        [Authorize]
        public async Task<Result<ChartAccountDTO>> GetByIdAsync(string id)
        {
            _logger.LogInformation($"{nameof(GetByIdAsync)} -> Start");

            return await _chartAccountService.GetByIdAsync(id);
        }

        [HttpPut(nameof(UpdateAsync))]
        [SwaggerOperation(nameof(UpdateAsync))]
        [Authorize]
        public async Task<Result<ChartAccountDTO>> UpdateAsync(ChartAccountDTO chartAccountDTO)
        {
            _logger.LogInformation($"{nameof(UpdateAsync)} -> Start");

            return await _chartAccountService.UpdateAsync(chartAccountDTO);
        }

        [HttpDelete(nameof(DeleteAsync))]
        [SwaggerOperation(nameof(DeleteAsync))]
        [Authorize]
        public async Task<Result<ChartAccountDTO>> DeleteAsync(string id)
        {
            _logger.LogInformation($"{nameof(DeleteAsync)} -> Start");

            return await _chartAccountService.DeleteAsync(id);
        }
    }
}