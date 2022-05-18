using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using cashflow.domain.DTO;
using cashflow.domain.Entity;
using cashflow.domain.Service;
using cashflow.infrastructure.common;

namespace cashflow.domain.Interface.Service
{
    public interface ICchartAccountService : IGenericService<FlowDTO, Flow>, IDisposable
    {
        Task<Result<FlowDTO>> AddAsync(FlowDTO flowDTO);
        Task<Result<FlowDTO>> UpdateAsync(FlowDTO flowDTO);
    }
}
