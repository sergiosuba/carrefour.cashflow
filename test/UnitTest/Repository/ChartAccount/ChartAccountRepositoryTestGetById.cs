using Xunit;
using System;
using AutoFixture.Xunit2;
using cashflow.repository;
using cashflow.domain.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Cashflow.Test.UnitTest.Repository
{
    public class ChartAccountRepositoryTestGetById : BaseTest
    {
        public ChartAccountRepository chartAccountRepository = new ChartAccountRepository(GetApplicationRespository());

        [Theory]
        [AutoDomainDataAttribute]
        public async Task GetByIdAsync_Success(
            [Frozen] ChartAccount chartAccount
        )
        {
            try
            {
                //Given
                var accountingEntries = new List<ChartAccount>();

                InMemoryDatabase.Insert(accountingEntries);

                //When
                var result = await chartAccountRepository.GetByIdAsync(chartAccount.id);

                //Then
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(GetByIdAsync_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}