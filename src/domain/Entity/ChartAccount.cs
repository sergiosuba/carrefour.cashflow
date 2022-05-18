using System;
using Dapper.Contrib.Extensions;

namespace cashflow.domain.Entity
{
    public class ChartAccount
    {

        [ExplicitKey]
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime creationDate { get; set; }
    }
}