using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using Cashflow.Test.UnitTest.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Cashflow.Test.UnitTest
{
    public class AutoDomainDataAttribute : AutoDataAttribute
    {
        private IServiceCollection _serviceCollection;
        public AutoDomainDataAttribute()
            : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            _serviceCollection = new ServiceCollection();

            _serviceCollection.AddScoped<IInMemoryDatabase, InMemoryDatabase>();
        }
    }
}