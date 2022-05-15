using System.Threading.Tasks;
using System.Collections.Generic;
using FluentValidation;
using cashflow.infrastructure.common;

namespace cashflow.domain.Services
{
    public interface IGenericService<T, TEntity> where T : class where TEntity : class
    {
        Task<Result<T>> AddAsync<TValidator>(T dto) where TValidator : AbstractValidator<T>;
        Task<Result<T>> GetByIdAsync(string id);
        Task<Result<IEnumerable<T>>> GetAllAsync<TFilter>(TFilter filterDTO);
        Task<Result<T>> UpdateAsync<TValidator>(T dto) where TValidator : AbstractValidator<T>;
        Task<Result<T>> DeleteAsync(string id);
        Task<Result<IEnumerable<dynamic>>> ExecuteStoredProcedureAsync(TEntity filterDTO);
    }
}
