using System;

namespace cashflow.domain.DTO
{
    public class AccountingEntryFilterDTO
    {
        public string ChartAccountId { get; set; }
        public decimal Value { get; set; }
        public string FlowId { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}