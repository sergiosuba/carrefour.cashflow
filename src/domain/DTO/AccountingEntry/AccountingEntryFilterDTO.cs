using System;

namespace cashflow.domain.DTO
{
    public class AccountingEntryFilterDTO
    {
        public DateTime? StarDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}