using System.Threading.Tasks;
using System.Collections.Generic;

namespace cashflow.domain.Interface.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity tentity);
        Task<TEntity> GetByIdAsync(string id);
        Task<IEnumerable<TEntity>> GetAllAsync<TFilter>(TFilter filter);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task<IEnumerable<dynamic>> ExecuteStoredProcedureAsync(TEntity filter);
    }
}