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

        public async Task<IEnumerable<dynamic>> GetAllViewAsync()
        {
            using (var conn = _connectionFactory.GetConnection())
            {
                sql = $"Select a.creationDate as Date, f.flow as Fluxo, Concat('R$ ', Format(IFNULL(SUM(a.value), 0), 2)) as Total " +
                       "From AccountingEntry a " +
                       "JOIN Flow f ON a.flowId = f.id " +
                       "WHERE '1 = 1 ' " +
                       "GROUP BY a.creationDate, f.flow ORDER BY a.creationDate DESC";

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