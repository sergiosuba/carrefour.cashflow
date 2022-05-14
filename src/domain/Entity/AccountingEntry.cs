using System;

namespace cashflow.domain.Entity
{
    public class AccountingEntry
    {
        string id { get; set; }
        string chartAccountId { get; set; }
        decimal value { get; set; }
        string flowId { get; set; }
        string description { get; set; }
        DateTime creationDate { get; set; }
    }
}