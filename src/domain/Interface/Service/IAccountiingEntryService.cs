using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using cashflow.infrastructure.common;
using cashflow.domain.DTO;
using cashflow.domain.Services;
using cashflow.domain.Entity;

namespace cashflow.domain.Services
{
    public interface IAccountingEntryService : IGenericService<AccountingEntryDTO, AccountingEntry>, IDisposable
    {
        Task<Result<AccountingEntryDTO>> AddAsync(AccountingEntryDTO accountingEntryDTO);
        Task<Result<AccountingEntryDTO>> UpdateAsync(AccountingEntryDTO accountingEntryDTO);
        Task<Result<IEnumerable<dynamic>>> GetAllViewAsync(AccountingEntryFilterDTO accountingEntryFilterDTO);
    }
}
