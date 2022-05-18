using Xunit;
using System;
using AutoFixture.Xunit2;
using cashflow.repository;
using cashflow.domain.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Cashflow.Test.UnitTest.Repository
{
    public class ChartAccountRepositoryTestDelete : BaseTest
    {
        public ChartAccountRepository chartAccountRepository = new ChartAccountRepository(GetApplicationRespository());

        [Theory]
        [AutoDomainDataAttribute]
        public async Task DeleteAsync_Success(
            [Frozen] ChartAccount chartAccount
        )
        {
            try
            {
                //Given
                var chartAccounts = new List<ChartAccount>();

                chartAccounts.Add(chartAccount);

                InMemoryDatabase.Insert(chartAccounts);

                //When
                var result = await chartAccountRepository.DeleteAsync(chartAccount);

                //Then
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(DeleteAsync_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}