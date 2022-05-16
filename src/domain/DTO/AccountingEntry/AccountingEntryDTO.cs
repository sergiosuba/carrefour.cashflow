using System;
using System.Text.Json.Serialization;

namespace cashflow.domain.DTO
{
    public class AccountingEntryDTO
    {
        public string Id { get; set; }
        public string ChartAccountId { get; set; }
        public decimal Value { get; set; }
        public string FlowId { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}