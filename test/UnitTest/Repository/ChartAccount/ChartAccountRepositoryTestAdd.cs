using Xunit;
using System;
using AutoFixture.Xunit2;
using cashflow.repository;
using cashflow.domain.Entity;
using System.Threading.Tasks;

namespace Cashflow.Test.UnitTest.Repository
{
    public class ChartAccountRepositoryTest : BaseTest
    {
        public ChartAccountRepository chartAccountRepository = new ChartAccountRepository(GetApplicationRespository());

        [Theory]
        [AutoDomainDataAttribute]
        public async Task AddAsyncTest_Success(
            [Frozen] ChartAccount chartAccount
        )
        {
            try
            {
                //Given
                InMemoryDatabase.CreateTable<ChartAccount>();

                //When
                await chartAccountRepository.AddAsync(chartAccount);

                //Then
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(AddAsyncTest_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}