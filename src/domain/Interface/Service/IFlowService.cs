using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using cashflow.domain.DTO;
using cashflow.domain.Entity;
using cashflow.domain.Service;
using cashflow.infrastructure.common;

namespace cashflow.domain.Interface.Service
{
    public interface IFlow : IGenericService<AccountingEntryDTO, AccountingEntry>, IDisposable
    {
        Task<Result<FlowtDTO>> AddAsync(FlowtDTO flowtDTO);
        Task<Result<FlowtDTO>> UpdateAsync(FlowtDTO flowtDTO);
        Task<Result<IEnumerable<dynamic>>> GetAllViewAsync();
    }
}
