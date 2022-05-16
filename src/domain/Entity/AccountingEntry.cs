using System;
using Dapper.Contrib.Extensions;

namespace cashflow.domain.Entity
{
    public class AccountingEntry
    {
        [ExplicitKey]
        public string id { get; set; }
        public string chartAccountId { get; set; }
        public decimal value { get; set; }
        public string flowId { get; set; }
        public string description { get; set; }
        public DateTime? creationDate { get; set; }
    }
}