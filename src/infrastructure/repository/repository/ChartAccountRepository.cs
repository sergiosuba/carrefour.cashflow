using cashflow.infrastructure.repository;
using cashflow.domain.Entity;
using cashflow.domain.Interface.Repository;

namespace cashflow.repository
{
    public class ChartAccountRepository : GenericRepository<ChartAccount>, IChartAccountRepository
    {
        private readonly IDatabaseConnectionFactory _connectionFactory;

        public ChartAccountRepository(IDatabaseConnectionFactory connectionFactory)
            : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
    }
}