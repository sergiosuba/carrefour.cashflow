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
    public class ChartAccountService : GenericService<ChartAccountDTO, ChartAccount>, IChartAccountService
    {
        private readonly IChartAccountRepository _chartAccountRepository;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ILogger<ChartAccountService> _logger;

        public ChartAccountService(IChartAccountRepository chartAccountRepository,
                                 IGenericRepository<ChartAccount> genericRepository,
                                 IValidation<ChartAccountDTO> validation,
                                 IMapper mapper,
                                 ILogger<ChartAccountService> logger,
                                 ILogger<GenericService<ChartAccountDTO, ChartAccount>> log,
                                 IExceptionHandler exceptionHandler)
            : base(genericRepository, validation, mapper, log, exceptionHandler)
        {
            _chartAccountRepository = chartAccountRepository;
            _logger = logger;
            _exceptionHandler = exceptionHandler;
        }

        public async Task<Result<ChartAccountDTO>> AddAsync(ChartAccountDTO chartAccountDTO)
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(AddAsync)}");

                chartAccountDTO.Id = System.Guid.NewGuid().ToString().ToUpper();
                chartAccountDTO.CreationDate = DateTime.Now;

                Dispose();

                return await AddAsync<ChartAccountValidator>(chartAccountDTO);
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to add record. Exception: {exception.MessageException}");

                Dispose();

                return Result.Fail<ChartAccountDTO>(exception.Code, "Unable to add record. Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }

        public async Task<Result<ChartAccountDTO>> UpdateAsync(ChartAccountDTO chartAccountDTO)
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(UpdateAsync)}");

                Dispose();

                return await UpdateAsync<ChartAccountValidator>(chartAccountDTO);
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to update record. Exception: {exception.MessageException}");

                Dispose();

                return Result.Fail<ChartAccountDTO>(exception.Code, "Unable to update record. Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }
    }
}
