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
    public class FlowRepository : GenericRepository<Flow>, IFlowRepository
    {
        private string sql = string.Empty;
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public FlowRepository(IDatabaseConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
    }
}