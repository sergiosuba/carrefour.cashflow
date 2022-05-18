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
    public class FlowService : GenericService<FlowDTO, Flow>, IFlowService
    {
        private readonly IFlowRepository _flowRepository;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ILogger<FlowService> _logger;

        public FlowService(IFlowRepository flowRepository,
                                 IGenericRepository<Flow> genericRepository,
                                 IValidation<FlowDTO> validation,
                                 IMapper mapper,
                                 ILogger<FlowService> logger,
                                 ILogger<GenericService<FlowDTO, Flow>> log,
                                 IExceptionHandler exceptionHandler)
            : base(genericRepository, validation, mapper, log, exceptionHandler)
        {
            _flowRepository = flowRepository;
            _logger = logger;
            _exceptionHandler = exceptionHandler;
        }

        public async Task<Result<FlowDTO>> AddAsync(FlowDTO flowDTO)
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(AddAsync)}");

                flowDTO.Id = System.Guid.NewGuid().ToString().ToUpper();

                Dispose();

                return await AddAsync<FlowValidator>(flowDTO);
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to add record. Exception: {exception.MessageException}");

                Dispose();

                return Result.Fail<FlowDTO>(exception.Code, "Unable to add record. Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }

        public async Task<Result<FlowDTO>> UpdateAsync(FlowDTO flowDTO)
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(UpdateAsync)}");

                Dispose();

                return await UpdateAsync<FlowValidator>(flowDTO);
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to update record. Exception: {exception.MessageException}");

                Dispose();

                return Result.Fail<FlowDTO>(exception.Code, "Unable to update record. Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }
    }
}
