using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using cashflow.domain.DTO;
using cashflow.domain.Entity;
using cashflow.domain.Service;
using cashflow.infrastructure.common;

namespace cashflow.domain.Interface.Service
{
    public interface IChartAccoutService : IGenericService<AccountingEntryDTO, AccountingEntry>, IDisposable
    {
        Task<Result<ChartAccountDTO>> AddAsync(ChartAccountDTO chartAccountDTO);
        Task<Result<ChartAccountDTO>> UpdateAsync(ChartAccountDTO chartAccountDTO);
        Task<Result<IEnumerable<dynamic>>> GetTotalByDateAsync();
    }
}
