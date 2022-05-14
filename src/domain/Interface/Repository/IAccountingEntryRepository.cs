using System.Collections.Generic;
using System.Threading.Tasks;
using cashflow.domain.DTO;
using cashflow.domain.Entity;

namespace cashflow.domain.Interface.Repository
{
    public interface IAccountingEntryRepository : IGenericRepository<AccountingEntry>
    {
        Task<IEnumerable<dynamic>> GetAllViewAsync(AccountingEntryFilterDTO filter);
    }
}