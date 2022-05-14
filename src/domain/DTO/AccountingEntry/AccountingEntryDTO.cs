using System;

namespace cashflow.domain.DTO
{
    public class AccountingEntryDTO
    {
        string Id { get; set; }
        string ChartAccountId { get; set; }
        decimal Value { get; set; }
        string FlowId { get; set; }
        string Description { get; set; }
        DateTime CreationDate { get; set; }
    }
}