using Xunit;
using System;
using AutoFixture.Xunit2;
using cashflow.repository;
using cashflow.domain.Entity;
using System.Threading.Tasks;
using System.Collections.Generic;
using cashflow.domain.DTO;

namespace Cashflow.Test.UnitTest.Repository
{
    public class ChartAccountRepositoryTestGetAll : BaseTest
    {
        public ChartAccountRepository chartAccountRepository = new ChartAccountRepository(GetApplicationRespository());

        [Theory]
        [AutoDomainDataAttribute]
        public async Task GetAllAsync_Success(
            [Frozen] ChartAccount chartAccount
        )
        {
            try
            {
                //Given
                var chartAccountFilterDTO = new ChartAccountFilterDTO();

                var chartAccounts = new List<ChartAccount>();

                InMemoryDatabase.Insert(chartAccounts);

                //When
                var result = await chartAccountRepository.GetAllAsync(chartAccountFilterDTO);

                //Then
                Assert.True(true);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{DateTime.Now} - Exception -> {GetType()}/{nameof(GetAllAsync_Success)} -> Message: {e.Message}");

                Assert.Null(e);
            }
        }
    }
}