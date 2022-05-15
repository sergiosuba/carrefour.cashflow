using System.Collections.Generic;
using System.Data;

namespace Cashflow.Test.UnitTest.Repository
{
    public interface IInMemoryDatabase
    {
        IDbConnection OpenConnection();
        void Insert<T>(IEnumerable<T> items);
        void CreateTable<T>();
    }
}