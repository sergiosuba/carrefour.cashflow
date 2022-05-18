using System;
using Dapper.Contrib.Extensions;

namespace cashflow.domain.Entity
{
    public class Flow
    {
        [ExplicitKey]
        public string id { get; set; }
        public string flow { get; set; }
    }
}