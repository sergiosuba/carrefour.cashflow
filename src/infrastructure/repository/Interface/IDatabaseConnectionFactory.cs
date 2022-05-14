using System;
using System.Data;

namespace cashflow.infrastructure.repository
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection GetConnection();
    }
}