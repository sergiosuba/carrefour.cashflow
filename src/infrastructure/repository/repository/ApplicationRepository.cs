using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Dapper;
using System;
using cashflow.infrastructure.repository;
using cashflow.domain.Entity;
using cashflow.domain.DTO;
using cashflow.domain.Interface.Repository;

namespace cashflow.repository
{
    public class AccountingEntryRepository : GenericRepository<AccountingEntry>, IAccountingEntryRepository
    {
        private string sql = string.Empty;
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public AccountingEntryRepository(IDatabaseConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<dynamic>> GetAllViewAsync(AccountingEntryFilterDTO accountingEntryFilterDTO)
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                sql = $"SELECT id, chartAccountId, value, flowId, description, creationDate " +
                      "FROM AccountingEntry " +
                      "WHERE 1 = 1 ";

                sql += "ORDER BY creationDate desc";

                try
                {
                    var result = await conn.QueryAsync<dynamic>(sql);

                    return result.ToList();
                }
                catch (Exception e)
                {
                    throw new Exception($"Error geting the record. Exception: {e.Message}");
                }
            }
        }
    }
}