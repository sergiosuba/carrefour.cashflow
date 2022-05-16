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
    public class AccountingEntryController : ControllerBase
    {
        private readonly IAccountingEntryService _accountingEntryService;
        private readonly ILogger<AccountingEntryController> _logger;

        public AccountingEntryController(IAccountingEntryService accountingEntryService,
                                    ILogger<AccountingEntryController> logger)
        {
            _accountingEntryService = accountingEntryService;
            _logger = logger;
        }

        [HttpPost(nameof(AddAsync))]
        [SwaggerOperation(nameof(AddAsync))]
        [Authorize]
        public async Task<Result<AccountingEntryDTO>> AddAsync(AccountingEntryDTO accountingEntryDTO)
        {
            _logger.LogInformation($"{nameof(AddAsync)} -> Start");

            return await _accountingEntryService.AddAsync(accountingEntryDTO);
        }

        [HttpPost(nameof(GetAllAsync))]
        [SwaggerOperation(nameof(GetAllAsync))]
        [Authorize]
        public async Task<Result<IEnumerable<AccountingEntryDTO>>> GetAllAsync(AccountingEntryFilterDTO accountingEntryFilterDTO)
        {
            _logger.LogInformation($"{nameof(GetAllAsync)} -> Start");

            return await _accountingEntryService.GetAllAsync(accountingEntryFilterDTO);
        }

        [HttpPost(nameof(GetAllViewAsync))]
        [SwaggerOperation(nameof(GetAllViewAsync))]
        [Authorize]
        public async Task<Result<IEnumerable<dynamic>>> GetAllViewAsync(AccountingEntryFilterDTO accountingEntryFilterDTO)
        {
            _logger.LogInformation($"{nameof(GetAllViewAsync)} -> Start");

            return await _accountingEntryService.GetAllViewAsync(accountingEntryFilterDTO);
        }

        [HttpGet(nameof(GetByIdAsync))]
        [SwaggerOperation(nameof(GetByIdAsync))]
        [Authorize]
        public async Task<Result<AccountingEntryDTO>> GetByIdAsync(string id)
        {
            _logger.LogInformation($"{nameof(GetByIdAsync)} -> Start");

            return await _accountingEntryService.GetByIdAsync(id);
        }

        [HttpPut(nameof(UpdateAsync))]
        [SwaggerOperation(nameof(UpdateAsync))]
        [Authorize]
        public async Task<Result<AccountingEntryDTO>> UpdateAsync(AccountingEntryDTO accountingEntryDTO)
        {
            _logger.LogInformation($"{nameof(UpdateAsync)} -> Start");

            return await _accountingEntryService.UpdateAsync(accountingEntryDTO);
        }

        [HttpDelete(nameof(DeleteAsync))]
        [SwaggerOperation(nameof(DeleteAsync))]
        [Authorize]
        public async Task<Result<AccountingEntryDTO>> DeleteAsync(string id)
        {
            _logger.LogInformation($"{nameof(DeleteAsync)} -> Start");

            return await _accountingEntryService.DeleteAsync(id);
        }
    }
}