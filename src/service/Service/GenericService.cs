using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using FluentValidation;
using cashflow.infrastructure.common;
using cashflow.domain.Services;
using cashflow.domain.Interface.Repository;

namespace cashflow.applicationservice
{
    public class GenericService<T, TEntity> : BaseAppService, IGenericService<T, TEntity> where T : class where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IValidation<T> _validation;
        private readonly IMapper _mapper;
        private readonly ILogger<GenericService<T, TEntity>> _logger;
        private readonly IExceptionHandler _exceptionHandler;
        public GenericService(IGenericRepository<TEntity> genericRepository,
                              IValidation<T> validation,
                              IMapper mapper,
                              ILogger<GenericService<T, TEntity>> logger,
                              IExceptionHandler exceptionHandler)
        {
            _genericRepository = genericRepository;
            _validation = validation;
            _mapper = mapper;
            _logger = logger;
            _exceptionHandler = exceptionHandler;
        }

        public async Task<Result<T>> AddAsync<TValidator>(T dto) where TValidator : AbstractValidator<T>
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(AddAsync)}");

                await _validation.ValidateAsync(dto, Activator.CreateInstance<TValidator>());

                var entity = _mapper.Map<TEntity>(dto);

                await _genericRepository.AddAsync(entity);

                _logger.LogInformation($"result -> {nameof(AddAsync)}");

                return Result.Ok<T>(201, "Record successfully added", dto);
            }
            catch (ValidationException e)
            {
                _logger.LogWarning($"Unable to add record. Warnning: {e.Message}");

                return Result.Fail<T>(400, $"Unable to add record. Contact the administrator.", e.Message);
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to add record. Exception: {exception.MessageException}");

                return Result.Fail<T>(exception.Code, "Unable to add record. Contact the administrator.", exception.MessageException);
            }
        }
        public async Task<Result<T>> GetByIdAsync(string id)
        {
            try
            {
                if (!Guid.TryParse(id, out Guid guid))
                    throw new Exception("The value must contain a valid guid.");

                _logger.LogInformation($"Executed -> {nameof(GetByIdAsync)}");

                var obj = await _genericRepository.GetByIdAsync(id);

                if (obj != null)
                {
                    var dto = _mapper.Map<T>(obj);

                    _logger.LogInformation($"result -> {nameof(GetByIdAsync)}");

                    return Result.Ok<T>(200, "Record successfully geted", dto);
                }
                else
                {
                    _logger.LogInformation($"result -> {nameof(GetByIdAsync)}");

                    return Result.Ok<T>(200, "Record not found", null);
                }
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to get application record. Exception: {exception.MessageException}");

                return Result.Fail<T>(exception.Code, "Unable to get a record. Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }
        public async Task<Result<IEnumerable<T>>> GetAllAsync<TFilter>(TFilter filterDTO)
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(GetAllAsync)}");

                var result = await _genericRepository.GetAllAsync(filterDTO);

                var dto = _mapper.Map<IEnumerable<T>>(result);

                if (Enumerable.Count(result) > 0)
                {
                    _logger.LogInformation($"result -> {nameof(GetAllAsync)}");

                    return Result.Ok<IEnumerable<T>>(200, "Record(s) successfully recovered", dto);
                }
                else
                {
                    _logger.LogInformation($"result -> {nameof(GetAllAsync)}");

                    return Result.Ok<IEnumerable<T>>(200, "Record not found", dto);
                }
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to get all record(s). Exception: {exception.MessageException}");

                return Result.Fail<IEnumerable<T>>(exception.Code, "Unable to get all record(s). Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }

        public async Task<Result<T>> UpdateAsync<TValidator>(T dto) where TValidator : AbstractValidator<T>
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(UpdateAsync)}");

                await _validation.ValidateAsync(dto, Activator.CreateInstance<TValidator>());

                var entity = _mapper.Map<TEntity>(dto);

                if (!await _genericRepository.UpdateAsync(entity))
                    throw new Exception("Unable to update record in database");

                _logger.LogInformation($"result -> {nameof(UpdateAsync)}");

                return Result.Ok<T>(200, "Record successfully updated", dto);
            }
            catch (ValidationException e)
            {
                _logger.LogWarning($"Unable to update record. Warnning: {e.Message}");

                return Result.Fail<T>(400, $"Unable to add record. Contact the administrator.", e.Message);
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to update record. Exception: {exception.MessageException}");

                return Result.Fail<T>(exception.Code, "Unable to update a record. Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }
        public async Task<Result<T>> DeleteAsync(string id)
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(DeleteAsync)}");

                if (!Guid.TryParse(id, out Guid guid))
                    throw new Exception("Record not found.");

                var entity = await _genericRepository.GetByIdAsync(id);

                if (entity != null)
                {
                    if (!await _genericRepository.DeleteAsync(entity))
                        throw new Exception("Unable to deleted record in database");

                    _logger.LogInformation($"result -> {nameof(DeleteAsync)}");

                    return Result.Ok<T>(200, "Record successfully deleted", null);
                }
                else
                {
                    _logger.LogInformation($"result -> {nameof(DeleteAsync)}");

                    return Result.Ok<T>(200, "Record not found", null);
                }
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to delete record. Exception: {exception.MessageException}");

                return Result.Fail<T>(exception.Code, "Unable to delete a record. Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }

        public async Task<Result<IEnumerable<dynamic>>> ExecuteStoredProcedureAsync(TEntity filter)
        {
            try
            {
                _logger.LogInformation($"Executed -> {nameof(ExecuteStoredProcedureAsync)}");

                var entity = _mapper.Map<TEntity>(filter);

                var result = await _genericRepository.ExecuteStoredProcedureAsync(entity);

                if (Enumerable.Count(result) > 0)
                {
                    _logger.LogInformation($"result -> {nameof(ExecuteStoredProcedureAsync)}");

                    return Result.Ok<IEnumerable<dynamic>>(200, "Record(s) successfully recovered", result);
                }
                else
                {
                    _logger.LogInformation($"result -> {nameof(ExecuteStoredProcedureAsync)}");

                    return Result.Ok<IEnumerable<dynamic>>(200, "Record not found", result);
                }
            }
            catch (Exception e)
            {
                var exception = _exceptionHandler.Handler(e);

                _logger.LogError($"Unable to get all record(s). Exception: {exception.MessageException}");

                return Result.Fail<IEnumerable<dynamic>>(exception.Code, "Unable to get all record(s). Contact the administrator.", $"Exception: {exception.MessageException}");
            }
        }
    }
}