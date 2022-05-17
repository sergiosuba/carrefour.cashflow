using System;

namespace cashflow.domain.DTO
{
    public class AccountingEntryFilterDTO
    {
        public string ChartAccountId { get; set; }
        public string FlowId { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}