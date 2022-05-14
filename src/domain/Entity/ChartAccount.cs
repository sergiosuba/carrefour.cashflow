using System;

namespace cashflow.domain.Entity
{
    public class ChartAccount
    {
        string id { get; set; }
        string name { get; set; }
        string description { get; set; }
        DateTime creationDate { get; set; }
    }
}