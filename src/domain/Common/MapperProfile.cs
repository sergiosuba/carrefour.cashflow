using AutoMapper;
using cashflow.domain.DTO;
using cashflow.domain.Entity;

namespace cashflow.domain.common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AccountingEntry, AccountingEntryDTO>();
            CreateMap<AccountingEntryDTO, AccountingEntry>();
            CreateMap<Flow, FlowDTO>();
            CreateMap<FlowDTO, Flow>();
            CreateMap<ChartAccount, ChartAccountDTO>();
            CreateMap<ChartAccountDTO, ChartAccount>();
        }
    }
}