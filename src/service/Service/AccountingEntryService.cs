using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using System;
using System.Linq;
using cashflow.domain.DTO;
using cashflow.domain.Entity;
using cashflow.domain.Validators;
using cashflow.infrastructure.common;
using cashflow.domain.Interface.Service;
using cashflow.domain.Interface.Repository;

namespace cashflow.service
{
    public class AccountingEntryService : GenericService<AccountingEntryDTO, AccountingEntry>, IAccountingEntryService
    {
        private readonly IAccountingEntryRepository _accountingEntryRepository;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ILogger<AccountingEntryService> _logger;

        public AccountingEntryService(IAccountingEntryRepository accountingEntryRepository,
                                 IGenericRepository<AccountingEntry> genericRepository,
                                 IValidation<AccountingEntryDTO> validation,
                                 IMapper mapper,
                                 ILogger<AccountingEntryService> logger,
                                 ILogger<GenericService<AccountingEntryDTO, AccountingEntry>> log,
                                 IExceptionHandler exceptionHandler)
            : base(genericRepository, validation, mapper, log, exceptionHandler)
        {
            _accountingEntryRepository = accountingEntryRepository;
            _logger = logger;
            _exceptionHandler = exceptionHandler;
        }

        public async Task<Result<AccountingEntryDTO>> AddAsync(AccountingEntryDTO accountingEntryDTO)
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(AddAsync)}");

                accountingEntryDTO.Id = System.Guid.NewGuid().ToString().ToUpper();

                Dispose();

                return await AddAsync<AccountingEntryValidator>(accountingEntryDTO);
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to add record. Exception: {exception.MessageException}");

                Dispose();

                return Result.Fail<AccountingEntryDTO>(exception.Code, "Unable to add record. Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }

        public async Task<Result<AccountingEntryDTO>> UpdateAsync(AccountingEntryDTO accountingEntryDTO)
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(UpdateAsync)}");

                Dispose();

                return await UpdateAsync<AccountingEntryValidator>(accountingEntryDTO);
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to update record. Exception: {exception.MessageException}");

                Dispose();

                return Result.Fail<AccountingEntryDTO>(exception.Code, "Unable to update record. Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }

        public async Task<Result<IEnumerable<dynamic>>> GetAllViewAsync(AccountingEntryFilterDTO accountingEntryFilterDTO)
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(GetAllAsync)}");

                var result = await _accountingEntryRepository.GetAllViewAsync(accountingEntryFilterDTO);

                if (Enumerable.Count(result) > 0)
                {
                    _logger.LogInformation($"result -> {nameof(GetAllAsync)}");

                    Dispose();

                    return Result.Ok<IEnumerable<dynamic>>(200, "Record(s) successfully recovered", result);
                }
                else
                {
                    _logger.LogInformation($"result -> {nameof(GetAllAsync)}");

                    Dispose();

                    return Result.Ok<IEnumerable<dynamic>>(200, "Record not found", result);
                }
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to get all record(s). Exception: {exception.MessageException}");

                Dispose();

                return Result.Fail<IEnumerable<dynamic>>(exception.Code, "Unable to get all record(s). Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }
    }
}
