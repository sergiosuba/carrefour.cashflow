using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using cashflow.domain.DTO;
using cashflow.domain.Entity;
using cashflow.domain.Service;
using cashflow.infrastructure.common;

namespace cashflow.domain.Interface.Service
{
    public interface IAccountingEntryService : IGenericService<AccountingEntryDTO, AccountingEntry>, IDisposable
    {
        Task<Result<AccountingEntryDTO>> AddAsync(AccountingEntryDTO accountingEntryDTO);
        Task<Result<AccountingEntryDTO>> UpdateAsync(AccountingEntryDTO accountingEntryDTO);
        Task<Result<IEnumerable<dynamic>>> GetTotalByDateAsync();
    }
}
