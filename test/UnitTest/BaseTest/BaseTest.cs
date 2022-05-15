using System;
using cashflow.infrastructure.repository;
using Cashflow.Test.UnitTest.Repository;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Cashflow.Test.UnitTest
{
    public abstract class BaseTest : AutoDomainDataAttribute
    {
        private IServiceCollection _serviceCollection;
        public static readonly IInMemoryDatabase InMemoryDatabase = new InMemoryDatabase();
        private static readonly Mock<IDatabaseConnectionFactory> _connectionFactoryMock = new Mock<IDatabaseConnectionFactory>();

        public BaseTest()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            Console.WriteLine($"Run Configure Services");

            _serviceCollection = new ServiceCollection();

            _serviceCollection.AddScoped<IInMemoryDatabase, InMemoryDatabase>();
        }

        public static IDatabaseConnectionFactory GetApplicationRespository()
        {
            _connectionFactoryMock.Setup(c => c.GetConnection()).Returns(InMemoryDatabase.OpenConnection());

            return _connectionFactoryMock.Object;
        }
    }
}